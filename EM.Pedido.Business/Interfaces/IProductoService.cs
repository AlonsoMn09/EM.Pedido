using EM.Pedido.DTO.Request;
using EM.Pedido.DTO.Request.Producto;
using EM.Pedido.DTO.Response;
using EM.Pedido.DTO.Response.Producto;
using EM.Pedido.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.Business.Interfaces
{
    public interface IProductoService
    {
        Task<BaseResponse> AddAsync(CreateProductoRequest request);
        Task<BaseResponse> UpdateAsync(int id, UpdateProductoRequest request);
        Task<BaseResponse<GetProductoResponse>> GetByIdAsync(int id);
        Task<PagedResponse<ListProductoResponse>> ListAsync(SearchListRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
