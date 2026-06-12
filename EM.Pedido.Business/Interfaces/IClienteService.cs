using EM.Pedido.DTO.Request;
using EM.Pedido.DTO.Request.Cliente;
using EM.Pedido.DTO.Response;
using EM.Pedido.DTO.Response.Cliente;
using EM.Pedido.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.Business.Interfaces
{
    public interface IClienteService
    {
        Task<BaseResponse> AddAsync(CreateClienteRequest request);
        Task<BaseResponse> UpdateAsync(int id, UpdateClienteRequest request);
        Task<BaseResponse<GetClienteResponse>> GetByIdAsync(int id);
        Task<PagedResponse<ListClienteResponse>> ListAsync(SearchListRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
