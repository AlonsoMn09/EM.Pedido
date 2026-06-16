using BlazorBootstrap;
using EM.Pedido.Business.Interfaces;
using EM.Pedido.DTO.Request.Pedido;
using EM.Pedido.DTO.Response.Cliente;
using EM.Pedido.DTO.Response.Producto;
using EM.Pedido.Entities;
using EM.Pedido.UI.Common;
using EM.Pedido.Utils;
using Microsoft.AspNetCore.Components;

namespace EM.Pedido.UI.Components.Pages.Features.Orders
{
    public partial class CreateOrder //: BaseComponent
    {
        [Inject]
        private IPedidoService _service { get; set; } = default!;
        [Inject]
        private ToastService Toast { get; set; } = default!;
        [Inject]
        private NavigationManager Navigation { get; set; } = default!;
        [Inject]
        private PreloadService PreloadService { get; set; } = default!;
        private Modal ModalClient { get; set; } = default!;

        private Modal ModalProduct { get; set; } = default!;

        private CreatePedidoRequest Request { get; set; } = new();

        private List<CreatePedidoDetalleRequest> RequestProducts { get; set; } = new();
        private decimal TotalBruto => RequestProducts.Sum(x => x.Total);
        private decimal TotalNeto => TotalBruto / Constants.IVA_NETO;

        private async Task OnSelectClient(ListClienteResponse item) 
        {
            Request.IdCliente = item.Id;
            Request.NombreCliente = item.RazonSocial;
            Request.NumeroDocumento = item.NumeroDocumento;
            await ModalClient.HideAsync();
        }

        private async Task OnSelectProducts(ListProductoResponse item)
        {
            var exists = RequestProducts.Any(x => x.IdProducto == item.Id);

            if (!exists)            
            RequestProducts.Add(new()
            {
                IdProducto = item.Id,
                PrecioUnitario = item.PrecioUnitario,
                Nombre = item.Nombre,
                Descripcion = item.Descripcion,
                Stock = item.Stock,
                Marca = item.Marca,
            });
        }

        private async Task OnRemoveProduct(CreatePedidoDetalleRequest item) 
        {
            RequestProducts.Remove(item);
        }

        private async Task OnSave() 
        {
            PreloadService.Show();
            try
            {
                Request.PedidoDetalles.AddRange(RequestProducts);
                var result = await _service.AddAsync(Request);
                if (result.IsSucess)
                {
                    Toast.Notify(new(ToastType.Success, "El pedido fue registrado exitosamente"));
                    Navigation.NavigateTo(ComponentRoutes.Orders.List);
                }
                else
                {
                    Toast.Notify(new(ToastType.Warning, result.Message!));
                }
            }
            catch (Exception ex)
            {
                Toast.Notify(new(ToastType.Danger, ex.Message));
            }
            finally 
            {
                PreloadService.Hide();
            }
        }
    }
}
