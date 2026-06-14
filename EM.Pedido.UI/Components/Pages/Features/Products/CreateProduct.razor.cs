//using Blazored.Toast.Services;
using EM.Pedido.Business.Interfaces;
using EM.Pedido.DTO.Request.Producto;
using EM.Pedido.DTO.Response.Catalogo;
using EM.Pedido.UI.Common;
using Microsoft.AspNetCore.Components;
using BlazorBootstrap;

namespace EM.Pedido.UI.Components.Pages.Features.Products
{
    public partial class CreateProduct
    {
        [Inject]
        private ICatalogoService _catalogoService { get; set; } = default!;

        [Inject]
        private IProductoService _service { get; set; } = default!;

        [Inject]
        private ToastService Toast { get; set; } = default!;

        [Inject]
        private NavigationManager _navigation { get; set; } = default!;

        [Inject]
        protected PreloadService PreloadService { get; set; } = default!;

        private List<ListCatalogoByCodigoResponse> ListMarcas { get; set; } = new();
        private List<ListCatalogoByCodigoResponse> ListCategorias { get; set; } = new();

        public CreateProductoRequest Request { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await GetCatalogos();
        }

        private async Task GetCatalogos()
        {
            PreloadService.Show(SpinnerColor.Light);
            try
            {
                var result = await _catalogoService.ListAsync(new List<string> { CodesCatalog.CATEGORIAS, CodesCatalog.MARCAS });
                if (result.IsSucess && result.Result != null)
                {
                    ListMarcas = result.Result.Where(x => x.CodigoPadre == CodesCatalog.MARCAS).ToList();
                    ListCategorias = result.Result.Where(x => x.CodigoPadre == CodesCatalog.CATEGORIAS).ToList();
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

        private async Task SaveProduct()
        {
            PreloadService.Show(SpinnerColor.Light);
            try
            {
                var result = await _service.AddAsync(Request);
                if (result.IsSucess)
                {
                    //Toast.ShowSuccess("Producte registrado correctamente.");
                    Toast.Notify(new(ToastType.Warning, result.Message!));
                    _navigation.NavigateTo(ComponentRoutes.Products.List);
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
