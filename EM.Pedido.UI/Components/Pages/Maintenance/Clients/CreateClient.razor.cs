using Blazored.Toast.Services;
using EM.Pedido.Business.Interfaces;
using EM.Pedido.DTO.Request.Cliente;
using EM.Pedido.DTO.Response.Catalogo;
using EM.Pedido.UI.Common;
using Microsoft.AspNetCore.Components;

namespace EM.Pedido.UI.Components.Pages.Maintenance.Clients
{
    public partial class CreateClient
    {
        [Inject]
        private ICatalogoService _catalogoService { get; set; } = default!;

        [Inject]
        private IClienteService _service { get; set; } = default!;

        [Inject]
        private IToastService Toast { get; set; } = default!;

        [Inject]
        private NavigationManager _navigation { get; set; } = default!;

        private List<ListCatalogoByCodigoResponse> ListRubros { get; set; } = new();
        private List<ListCatalogoByCodigoResponse> ListTipoDoc { get; set; } = new();

        public CreateClienteRequest Request { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await ListaCatalogos();
        }

        private async Task ListaCatalogos()
        {
            try
            {
                var result = await _catalogoService.ListAsync(new List<string> { "MAE_RUBROS", "MAE_TIPO_DOC" });
                if (result.IsSucess && result.Result != null)
                {
                    ListRubros = result.Result.Where(x => x.CodigoPadre == "MAE_RUBROS").ToList();
                    ListTipoDoc = result.Result.Where(x => x.CodigoPadre == "MAE_TIPO_DOC").ToList();
                }
                else
                {
                    Toast.ShowError(result.Messagge);
                }
            }
            catch (Exception ex)
            {
                Toast.ShowError(ex.Message);
            }

        }

        private async Task SaveClient() {
            var result = await _service.AddAsync(Request);
            if (result.IsSucess)
            {
                Toast.ShowSuccess("Cliente registrado correctamente.");
                _navigation.NavigateTo(ComponentRoutes.Clientes.List);
            }
            else
            {
                Toast.ShowError(result.Messagge);
            }
        }
    }
}
