using EM.Pedido.DTO.Request;
using EM.Pedido.DTO.Response;
using EM.Pedido.DTO.Response.Catalogo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.Business.Interfaces
{
    public interface ICatalogoService
    {
        Task<BaseResponse<List<ListCatalogoByCodigoResponse>>> ListAsync(List<string> listCodigos);
    }
}
