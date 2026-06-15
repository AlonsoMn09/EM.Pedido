using Azure.Core;
using EM.Pedido.Business.Interfaces;
using EM.Pedido.DTO.Request;
using EM.Pedido.DTO.Request.Cliente;
using EM.Pedido.DTO.Response;
using EM.Pedido.DTO.Response.Cliente;
using EM.Pedido.Entities;
using EM.Pedido.Repositories.Interfaces;
using EM.Pedido.Utils;
using Mapster;
using Microsoft.Extensions.Logging;

namespace EM.Pedido.Business.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly ILogger<ClienteService> _logger;

        public ClienteService(IClienteRepository repository, ILogger<ClienteService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<BaseResponse> AddAsync(CreateClienteRequest request)
        {
            var response = new BaseResponse();
            try
            {
                /*var cliente = new Cliente()
                {
                    RazonSocial = request.RazonSocial,
                    IdTipoDocumentoCat = request.IdTipoDocumentoCat,
                    NumeroDocumento = request.NumeroDocumento,
                    Representante = request.Representante,
                    Direccion = request.Direccion,
                    Email = request.Email,
                    Celular = request.Celular,
                    IdRubroCat = request.IdRubroCat
                };

                await _repository.AddAsync(cliente);*/
                await _repository.AddAsync(request.Adapt<Cliente>());
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = "Ocurrió un error al agregar cliente.";
                _logger.LogError(ex, "{0} - {1}", response.Message, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, UpdateClienteRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var cliente = await _repository.GetByAsync(id);
                if (cliente is null)
                {
                    response.IsSucess = true;
                    response.ErrorCode = "CLIENTE_NOT_FOUND";
                    response.Message = "Cliente no encontrado.";
                    return response;
                }
                request.Adapt(cliente);
                await _repository.UpdateAsync();
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = "Ocurrió un error al actualizar cliente.";
                _logger.LogError(ex, "{0} - {1}", response.Message, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse<GetClienteResponse>> GetByIdAsync(int id)
        {
            var response = new BaseResponse<GetClienteResponse>();
            try
            {
                var cliente = await _repository.GetByAsync(id);
                if (cliente is null)
                {
                    response.IsSucess = true;
                    response.ErrorCode = "CLIENTE_NOT_FOUND";
                    response.Message = "Cliente no encontrado.";
                    return response;
                }
                response.Result = cliente.Adapt<GetClienteResponse>();
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = "Ocurrió un error al obtener cliente.";
                _logger.LogError(ex, "{0} - {1}", response.Message, ex.Message);
            }
            return response;
        }

        public async Task<PagedResponse<ListClienteResponse>> ListAsync(SearchListRequest request)
        {
            var response = new PagedResponse<ListClienteResponse>();
            try
            {
                var result = await _repository.ListAsync(
                    predicate: p => p.Estado && (
                        (string.IsNullOrEmpty(request.Filter) || p.RazonSocial.Contains(request.Filter)) ||
                        (string.IsNullOrEmpty(request.Filter) || p.NumeroDocumento.Contains(request.Filter))
                    ),
                    selector: p => new ListClienteResponse {
                        Id = p.Id,
                        Rubro = p.IdRubroCatNavigation.Valor!,
                        Celular = p.Celular,
                        Direccion = p.Direccion,
                        Email = p.Email,
                        FechaRegistro = p.FechaCreacion,
                        NumeroDocumento = p.NumeroDocumento,
                        RazonSocial = p.RazonSocial,
                        Representante = p.Representante,
                        TipoDocumento = p.IdTipoDocumentoCatNavigation.Valor!
                    },
                    orderBy: p => p.RazonSocial,
                    page: request.Page,
                    pageSize: request.Rows
                );
                response.IsSucess = true;
                response.Result = result.Result;
                response.TotalRowsPerPages = result.TotalRows; // result.Result.Count;
                response.TotalPages = Helpers.CalculatePageCount(result.TotalRows, request.Rows);
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = "Ocurrió un error al listar clientes.";
                _logger.LogError(ex, "{0} - {1}", response.Message, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();
            try
            {
                var cliente = await _repository.GetByAsync(id);
                if (cliente is null)
                {
                    response.IsSucess = true;
                    response.ErrorCode = "CLIENTE_NOT_FOUND";
                    response.Message = "Cliente no encontrado.";
                    return response;
                }              
                await _repository.DeleteAsync(id);
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = "Ocurrió un error al eliminar cliente.";
                _logger.LogError(ex, "{0} - {1}", response.Message, ex.Message);
            }
            return response;
        }
    }
}
