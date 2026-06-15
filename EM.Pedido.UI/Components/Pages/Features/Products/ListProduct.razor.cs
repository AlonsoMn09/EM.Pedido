//using Blazored.Toast.Services;
using BlazorBootstrap;
using CurrieTechnologies.Razor.SweetAlert2;
using EM.Pedido.Business.Interfaces;
using EM.Pedido.DTO.Request;
using EM.Pedido.DTO.Response;
using EM.Pedido.DTO.Response.Producto;
using EM.Pedido.UI.Components.Shared;
using Microsoft.AspNetCore.Components;

namespace EM.Pedido.UI.Components.Pages.Features.Products
{
    public partial class ListProduct
    {
        [Inject]
        private IProductoService _service { get; set; } = default!;

        [Inject]
        private SweetAlertService Swal { get; set; } = default!;

        [Inject]
        private ToastService Toast { get; set; } = default!; //private IToastService Toast { get; set; } = default!; 

        private bool IsLoading { get; set; } = default!;
        //private Loading Loading { get; set; } = default!;
        //[Inject]
        //protected PreloadService PreloadService { get; set; } = default!;

        public SearchListRequest Request { get; set; } = new();

        public ICollection<ListProductoResponse> Response { get; set; } = new List<ListProductoResponse>();

        [Inject]
        public NavigationManager Navigation { get; set; } = default!;

        private PagerRequest Pager { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await ListProducts();
        }

        private async Task Refresh() {
            Request = new();
            await ListProducts();
        }

        private async Task ListProducts() {
            //PreloadService.Show(SpinnerColor.Light, "Loading data...");
            //await Task.Delay(5000);
            //Loading.IsLoading = true;
            IsLoading = true;
            try
            {
                var result = await _service.ListAsync(Request);
                if (result!.IsSucess)
                {
                    Response = result.Result;
                    Pager = new PagerRequest
                    {
                        CurrentPage = Request.Page,
                        TotalPages = result.TotalPages,
                        TotalRows = result.TotalRowsPerPages,
                        RowsPerPage = Request.Rows
                    };
                }
                else
                {
                    //Toast.ShowError(result.Messagge);
                    Toast.Notify(new(ToastType.Warning, result.Message!));
                }
            }
            catch (Exception ex)
            {
                //Toast.ShowError($"Hubo un error desconocido: {ex.Message}");
                Toast.Notify(new(ToastType.Danger, $"Hubo un error desconocido: {ex.Message}"));
            }
            finally {
                //PreloadService.Hide();
                //Loading.IsLoading = false;
                IsLoading = false;
            }
        }

        private async Task OnPager()
        {
            Request.Page = Pager.CurrentPage;
            Request.Rows = Pager.RowsPerPage;
            await ListProducts();
        }

        private async Task Delete(ListProductoResponse item) {
            try
            {
                var result = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Eliminar producto",
                    Text = $"Está a punto de eliminar el producto {item.Nombre}, no podrá recuperar el registro",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Eliminar",
                    CancelButtonText = "Cancelar"
                });

                if (result.IsConfirmed)
                {
                    IsLoading = true;
                    var resultDelete = await _service.DeleteAsync(item.Id);
                    if (resultDelete.IsSucess)
                    {
                        await ListProducts();
                        IsLoading = false;
                        await Swal.FireAsync(
                            "Eliminado",
                            $"El producto {item.Nombre} fue eliminado exitosamente.",
                            SweetAlertIcon.Success
                        );                        
                    }
                }
            }
            catch (Exception ex)
            {
                Toast.Notify(new(ToastType.Danger, $"Hubo un error desconocido: {ex.Message}"));
            }
            finally {
                
            }
        }

        private async Task ToEdit(int id) =>
            Navigation.NavigateTo($"{Common.ComponentRoutes.Products.Edit}/{id}");
    }
}
