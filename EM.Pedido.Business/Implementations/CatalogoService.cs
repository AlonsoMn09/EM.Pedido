using Azure.Core;
using EM.Pedido.Business.Interfaces;
using EM.Pedido.DTO.Request;
using EM.Pedido.DTO.Response;
using EM.Pedido.DTO.Response.Catalogo;
using EM.Pedido.Entities;
using EM.Pedido.Repositories.Interfaces;
using Mapster;
using Microsoft.Extensions.Logging;

namespace EM.Pedido.Business.Implementations
{
    public class CatalogoService : ICatalogoService
    {
        private readonly ICatalogoDetalleRepository _repository;
        private readonly ILogger<CatalogoService> _logger;

        public CatalogoService(ICatalogoDetalleRepository repository, ILogger<CatalogoService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        
        public async Task<BaseResponse<List<ListCatalogoByCodigoResponse>>> ListAsync(List<string> listCodigos)
        {
            var response = new BaseResponse<List<ListCatalogoByCodigoResponse>>();
            try
            {
                var result = await _repository.ListAsync(
                    predicate: p => p.Estado && listCodigos.Any(l => l == p.IdCatalogoNavigation.Codigo),
                    selector: p => new ListCatalogoByCodigoResponse
                    {
                        Id = p.Id,
                        CodigoPadre = p.IdCatalogoNavigation.Codigo,
                        Codigo = p.Codigo,
                        Valor = p.Valor!
                    },
                   orderBy: p => p.Valor
                );
                response.IsSucess = true;
                response.Result = result.ToList();
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = "Ocurrió un error al listar catalogos.";
                _logger.LogError(ex, "{0} - {1}", response.Message, ex.Message);
            }
            return response;
        }
    }
}
