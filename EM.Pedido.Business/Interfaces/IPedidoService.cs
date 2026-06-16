using EM.Pedido.DTO.Request;
using EM.Pedido.DTO.Request.Pedido;
using EM.Pedido.DTO.Response;
using EM.Pedido.DTO.Response.Pedido;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.Business.Interfaces
{
    public interface IPedidoService
    {
        Task<BaseResponse> AddAsync(CreatePedidoRequest request);
        Task<PagedResponse<ListPedidoResponse>> ListAsync(SearchListRequest request);
        Task<BaseResponse<MemoryStream>> ExportListAsync(SearchListRequest request)
    }
}
