//using Blazored.Toast.Services;
using BlazorBootstrap;
using EM.Pedido.Business.Interfaces;
using EM.Pedido.DTO.Request.Cliente;
using EM.Pedido.DTO.Response.Catalogo;
using EM.Pedido.UI.Common;
using EM.Pedido.Utils;
using Microsoft.AspNetCore.Components;

namespace EM.Pedido.UI.Components.Pages.Features.Clients
{
    public partial class EditClient
    {
        [Parameter]
        public int id { get; set; }

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
            await GetCatalogosAsync();
            await GetByIdAsync();
        }

        private async Task GetCatalogosAsync()
        {
            PreloadService.Show(SpinnerColor.Light);
            try
            {
                var result = await _catalogoService.ListAsync(new List<string> { CodesCatalog.RUBROS , CodesCatalog.TIPO_DOC });
                if (result.IsSucess && result.Result != null)
                {
                    ListRubros = result.Result.Where(x => x.CodigoPadre == CodesCatalog.RUBROS).ToList();
                    ListTipoDoc = result.Result.Where(x => x.CodigoPadre == CodesCatalog.TIPO_DOC).ToList();
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
            finally {
                PreloadService.Hide();
            }
        }

        private async Task GetByIdAsync()
        {
            PreloadService.Show(SpinnerColor.Light);
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result.IsSucess && result.Result != null)
                {
                    Request.RazonSocial = result.Result.RazonSocial;
                    Request.IdTipoDocumentoCat = result.Result.IdTipoDocumentoCat;
                    Request.NumeroDocumento = result.Result.NumeroDocumento;
                    Request.Representante = result.Result.Representante;
                    Request.Direccion = result.Result.Direccion;
                    Request.Email = result.Result.Email;
                    Request.Celular = result.Result.Celular;
                    Request.IdRubroCat = result.Result.IdRubroCat;
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
                var update = new UpdateClienteRequest
                {
                    RazonSocial = Request.RazonSocial,
                    IdTipoDocumentoCat = Request.IdTipoDocumentoCat,
                    NumeroDocumento = Request.NumeroDocumento,
                    Representante = Request.Representante,
                    Direccion = Request.Direccion,
                    Email = Request.Email,
                    Celular = Request.Celular,
                    IdRubroCat = Request.IdRubroCat
                };

                var result = await _service.UpdateAsync(id, update);
                if (result.IsSucess)
                {
                    //Toast.ShowSuccess("Cliente registrado correctamente.");
                    Toast.Notify(new(ToastType.Success, result.Message!));
                    _navigation.NavigateTo(ComponentRoutes.Clients.List);
                }
                else
                {
                    //Toast.ShowError(result.Messagge);
                    Toast.Notify(new(ToastType.Danger, result.Message!));
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
