//using Blazored.Toast.Services;
using EM.Pedido.Business.Interfaces;
using EM.Pedido.DTO.Request.Cliente;
using EM.Pedido.DTO.Response.Catalogo;
using EM.Pedido.UI.Common;
using Microsoft.AspNetCore.Components;
using BlazorBootstrap;

namespace EM.Pedido.UI.Components.Pages.Features.Clients
{
    public partial class CreateClient
    {
        [Inject]
        private ICatalogoService _catalogoService { get; set; } = default!;

        [Inject]
        private IClienteService _service { get; set; } = default!;

        [Inject]
        private ToastService Toast { get; set; } = default!;

        [Inject]
        private NavigationManager _navigation { get; set; } = default!;

        [Inject]
        protected PreloadService PreloadService { get; set; } = default!;

        private List<ListCatalogoByCodigoResponse> ListRubros { get; set; } = new();
        private List<ListCatalogoByCodigoResponse> ListTipoDoc { get; set; } = new();

        public CreateClienteRequest Request { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await GetCatalogos();
        }

        private async Task GetCatalogos()
        {
            PreloadService.Show(SpinnerColor.Light);
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
                    //Toast.ShowError(result.Messagge);
                    Toast.Notify(new(ToastType.Warning, result.Message!));
                }
            }
            catch (Exception ex)
            {
                //Toast.ShowError(ex.Message);
                Toast.Notify(new(ToastType.Danger, ex.Message));
            }
            finally
            {
                PreloadService.Hide();
            }
        }

        private async Task SaveClient()
        {
            PreloadService.Show(SpinnerColor.Light);
            try
            {
                var result = await _service.AddAsync(Request);
                if (result.IsSucess)
                {
                    //Toast.ShowSuccess("Cliente registrado correctamente.");
                    Toast.Notify(new(ToastType.Warning, result.Message!));
                    _navigation.NavigateTo(ComponentRoutes.Clients.List);
                }
                else
                {
                    //Toast.ShowError(result.Messagge);
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
