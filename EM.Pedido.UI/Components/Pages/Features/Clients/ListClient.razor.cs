//using Blazored.Toast.Services;
using BlazorBootstrap;
using CurrieTechnologies.Razor.SweetAlert2;
using EM.Pedido.Business.Interfaces;
using EM.Pedido.DTO.Request;
using EM.Pedido.DTO.Response;
using EM.Pedido.DTO.Response.Cliente;
using EM.Pedido.UI.Components.Shared;
using Microsoft.AspNetCore.Components;

namespace EM.Pedido.UI.Components.Pages.Features.Clients
{
    public partial class ListClient
    {
        [Inject]
        private IClienteService _service { get; set; } = default!;

        [Inject]
        private SweetAlertService Swal { get; set; } = default!;

        [Inject]
        private ToastService Toast { get; set; } = default!; //private IToastService Toast { get; set; } = default!; 

        private bool IsLoading { get; set; } = default!;
        //private Loading Loading { get; set; } = default!;
        //[Inject]
        //protected PreloadService PreloadService { get; set; } = default!;

        public SearchListRequest Request { get; set; } = new();

        public ICollection<ListClienteResponse> Response { get; set; } = new List<ListClienteResponse>();

        [Inject]
        public NavigationManager Navigation { get; set; } = default!;

        private PagerRequest Pager { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await ListClients();
        }

        private async Task Refresh() {
            Request = new();
            await ListClients();
        }

        private async Task ListClients() {
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
            await ListClients();
        }

        private async Task Delete(ListClienteResponse item) {
            try
            {
                var result = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Eliminar cliente",
                    Text = $"Está a punto de eliminar a {item.RazonSocial}, no podrá recuperar el registro",
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
                        await ListClients();
                        IsLoading = false;
                        await Swal.FireAsync(
                            "Eliminado",
                            $"El cliente {item.RazonSocial} fue eliminado exitosamente.",
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
            Navigation.NavigateTo($"{Common.ComponentRoutes.Clients.Edit}/{id}");
    }
}
