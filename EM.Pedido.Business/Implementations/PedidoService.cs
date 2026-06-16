using EM.Pedido.Business.Interfaces;
using EM.Pedido.DTO.Request;
using EM.Pedido.DTO.Request.Pedido;
using EM.Pedido.DTO.Response;
using EM.Pedido.DTO.Response.Pedido;
using EM.Pedido.Entities;
using EM.Pedido.Repositories.Interfaces;
using EM.Pedido.Utils;
using Mapster;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace EM.Pedido.Business.Implementations
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ILogger<PedidoService> _logger;
        private readonly IExcelService _excel;

        public PedidoService(
            IPedidoRepository pedidoRepository
            , ILogger<PedidoService> logger
            , IExcelService excel)
        {
            _pedidoRepository = pedidoRepository;
            _logger = logger;
            _excel = excel;
        }

        public async Task<BaseResponse> AddAsync(CreatePedidoRequest request)
        { 
            var response = new BaseResponse();
            try
            {
                var order = request.Adapt<Pedidos>();
                CalculateTotal(order);
                await _pedidoRepository.CreateAsync(order);
                response.IsSucess = true;
                response.Message = "Pedido creado exitosamente.";
            }
            catch (Exception ex)
            {
                response.Message = "Error al crear el pedido.";
                _logger.LogError(ex, "{0} - {1}", response.Message, ex.Message);
            }
            return response;
        }

        private static void CalculateTotal(Pedidos request)
        {
            _ = request.PedidoDetalles.Select(x =>
            {
                x.TotalBruto = x.Cantidad * x.PrecioUnitario;
                x.TotalNeto = x.TotalBruto / Constants.IVA_NETO;
                return x;
            });

            request.TotalBruto = request.PedidoDetalles.Sum(x => x.TotalBruto);
            request.TotalNeto = request.TotalBruto / Constants.IVA_NETO;
          // return request;
        }

        public async Task<PagedResponse<ListPedidoResponse>> ListAsync(SearchListRequest request) 
        { 
            var response = new PagedResponse<ListPedidoResponse>();
            try
            {
                var result = await _pedidoRepository.ListAsync(
                    predicate: p => p.Estado &&
                        (
                            (string.IsNullOrEmpty(request.Filter) || p.IdClienteNavigation.RazonSocial.Contains(request.Filter)) ||
                            (string.IsNullOrEmpty(request.Filter) || p.IdClienteNavigation.NumeroDocumento.Contains(request.Filter))
                        ),
                    selector: p => new ListPedidoResponse
                    {
                        Id = p.Id,
                        IdCliente = p.IdCliente,
                        RazonSocial = p.IdClienteNavigation.RazonSocial,
                        NumeroDocumento = p.IdClienteNavigation.NumeroDocumento,
                        TotalBruto = p.TotalBruto,
                        TotalNeto = p.TotalNeto,
                        Total = p.TotalBruto - p.Adelanto,
                        Adelanto = p.Adelanto,
                        CantidadProductos = p.PedidoDetalles.Count,
                        FechaRegistro = p.FechaCreacion
                    },
                    orderBy: p => p.FechaCreacion,
                    page: request.Page,
                    pageSize: request.Rows
                );

                response.IsSucess = true;
                response.Result = result.Result;
                response.TotalPages = Helpers.CalculatePageCount(result.TotalRows, request.Rows);
                response.TotalRowsPerPages = result.TotalRows;
            }
            catch (Exception ex)
            {
                response.Message = "Error al listar pedido.";
                _logger.LogError(ex, "{0} - {1}", response.Message, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse<MemoryStream>> ExportListAsync(SearchListRequest request)
        {
            var response = new BaseResponse<MemoryStream>();
            try
            {
                var result = await _pedidoRepository.ListAsync(
                    predicate: p => p.Estado &&
                        (
                            (string.IsNullOrEmpty(request.Filter) || p.IdClienteNavigation.RazonSocial.Contains(request.Filter)) ||
                            (string.IsNullOrEmpty(request.Filter) || p.IdClienteNavigation.NumeroDocumento.Contains(request.Filter))
                        ),
                    selector: p => new ListPedidoResponse
                    {
                        Id = p.Id,
                        IdCliente = p.IdCliente,
                        RazonSocial = p.IdClienteNavigation.RazonSocial,
                        NumeroDocumento = p.IdClienteNavigation.NumeroDocumento,
                        TotalBruto = p.TotalBruto,
                        TotalNeto = p.TotalNeto,
                        Total = p.TotalBruto - p.Adelanto,
                        Adelanto = p.Adelanto,
                        CantidadProductos = p.PedidoDetalles.Count,
                        FechaRegistro = p.FechaCreacion
                    },
                    orderBy: p => p.FechaCreacion,
                    page: request.Page,
                    pageSize: Constants.MaxExportRows
                );

                response.IsSucess = true;
                response.Result = _excel.ExportExcel(result.Result, "Pedidos");
            }
            catch (Exception ex)
            {
                response.Message = "Error al exportar los pedidos.";
                _logger.LogError(ex, "{0} - {1}", response.Message, ex.Message);
            }
            return response;
        }
    }
}
