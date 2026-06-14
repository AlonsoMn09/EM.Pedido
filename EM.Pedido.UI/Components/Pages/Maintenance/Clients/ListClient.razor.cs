using Blazored.Toast.Services;
using EM.Pedido.Business.Interfaces;
using EM.Pedido.DTO.Request;
using EM.Pedido.DTO.Response;
using EM.Pedido.DTO.Response.Cliente;
using Microsoft.AspNetCore.Components;

namespace EM.Pedido.UI.Components.Pages.Maintenance.Clients
{
    public partial class ListClient
    {
        [Inject]
        private IClienteService _service { get; set; } = default!;

        [Inject]
        private IToastService Toast { get; set; } = default!; 

        public SearchListRequest Request { get; set; } = new();

        public ICollection<ListClienteResponse> Response { get; set; } = new List<ListClienteResponse>();

        [Inject]
        public NavigationManager Navigation { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await ListClients();
        }

        private async Task ListClients() {
            try
            {
                var result = await _service.ListAsync(Request);
                if (result!.IsSucess)
                {
                    Response = result.Result;
                }
                else
                {
                    Toast.ShowError(result.Messagge);
                }
            }
            catch (Exception ex)
            {
                Toast.ShowError($"Hubo un error desconocido: {ex.Message}");
            }
        }

        private async Task ToEdit(int id) =>
            Navigation.NavigateTo($"{Common.ComponentRoutes.Clientes.Edit}/{id}");
    }
}
