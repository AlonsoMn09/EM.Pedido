using Azure.Core;
using EM.Pedido.Business.Interfaces;
using EM.Pedido.DTO.Request;
using EM.Pedido.DTO.Request.Producto;
using EM.Pedido.DTO.Response;
using EM.Pedido.DTO.Response.Producto;
using EM.Pedido.Entities;
using EM.Pedido.Repositories.Interfaces;
using Mapster;
using Microsoft.Extensions.Logging;

namespace EM.Pedido.Business.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;
        private readonly ILogger<ProductoService> _logger;

        public ProductoService(IProductoRepository repository, ILogger<ProductoService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<BaseResponse> AddAsync(CreateProductoRequest request)
        {
            var response = new BaseResponse();
            try
            {
                /*var Producto = new Producto()
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

                await _repository.AddAsync(Producto);*/
                await _repository.AddAsync(request.Adapt<Producto>());
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = "Ocurrió un error al agregar Producto.";
                _logger.LogError(ex, "{0} - {1}", response.Message, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, UpdateProductoRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var Producto = await _repository.GetByAsync(id);
                if (Producto is null)
                {
                    response.IsSucess = true;
                    response.ErrorCode = "Producto_NOT_FOUND";
                    response.Message = "Producto no encontrado.";
                    return response;
                }
                request.Adapt(Producto);
                await _repository.UpdateAsync();
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = "Ocurrió un error al actualizar Producto.";
                _logger.LogError(ex, "{0} - {1}", response.Message, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse<GetProductoResponse>> GetByIdAsync(int id)
        {
            var response = new BaseResponse<GetProductoResponse>();
            try
            {
                var Producto = await _repository.GetByAsync(id);
                if (Producto is null)
                {
                    response.IsSucess = true;
                    response.ErrorCode = "Producto_NOT_FOUND";
                    response.Message = "Producto no encontrado.";
                    return response;
                }
                response.Result = Producto.Adapt<GetProductoResponse>();
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = "Ocurrió un error al obtener Producto.";
                _logger.LogError(ex, "{0} - {1}", response.Message, ex.Message);
            }
            return response;
        }

        public async Task<PagedResponse<ListProductoResponse>> ListAsync(SearchListRequest request)
        {
            var response = new PagedResponse<ListProductoResponse>();
            try
            {
                var result = await _repository.ListAsync(
                    predicate: p => p.Estado && (
                        (string.IsNullOrEmpty(request.Filter) || p.Nombre.Contains(request.Filter)) ||
                        (string.IsNullOrEmpty(request.Filter) || p.Descripcion.Contains(request.Filter))
                    ),
                    selector: p => new ListProductoResponse {
                        Id = p.Id,
                        Categoria = p.IdCategoriaCatNavigation.Valor!,
                        Descripcion = p.Descripcion,
                        Marca = p.IdMarcaCatNavigation.Valor!,
                        Nombre = p.Nombre,
                        PrecioUnitario = p.PrecioUnitario,
                        Stock = p.Stock,
                        FechaRegistro = p.FechaCreacion
                    },
                    orderBy: p => p.Nombre,
                    page: request.Page,
                    pageSize: request.Rows
                );
                response.IsSucess = true;
                response.Result = result.Result;
                response.TotalRowsPerPages = result.Result.Count;
                response.TotalPages = (int)Math.Ceiling((double)result.TotalRows / request.Rows);
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = "Ocurrió un error al listar Productos.";
                _logger.LogError(ex, "{0} - {1}", response.Message, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();
            try
            {
                var Producto = await _repository.GetByAsync(id);
                if (Producto is null)
                {
                    response.IsSucess = true;
                    response.ErrorCode = "Producto_NOT_FOUND";
                    response.Message = "Producto no encontrado.";
                    return response;
                }              
                await _repository.DeleteAsync(id);
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = "Ocurrió un error al eliminar Producto.";
                _logger.LogError(ex, "{0} - {1}", response.Message, ex.Message);
            }
            return response;
        }
    }
}
