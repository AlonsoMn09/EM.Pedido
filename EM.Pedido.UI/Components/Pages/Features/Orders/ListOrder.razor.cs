using BlazorBootstrap;
using CurrieTechnologies.Razor.SweetAlert2;
using EM.Pedido.Business.Interfaces;
using EM.Pedido.DTO.Request;
using EM.Pedido.DTO.Response.Pedido;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace EM.Pedido.UI.Components.Pages.Features.Orders
{
    public partial class ListOrder
    {
        [Inject]
        private IPedidoService _service { get; set; } = default!;

        [Inject]
        private SweetAlertService Swal { get; set; } = default!;

        [Inject]
        private ToastService Toast { get; set; } = default!;

        private bool IsLoading { get; set; } = default!;

        public SearchListRequest Request { get; set; } = new();

        [Inject]
        public NavigationManager Navigation { get; set; } = default!;

        public ICollection<ListPedidoResponse> Response { get; set; } = new List<ListPedidoResponse>();

        private PagerRequest Pager { get; set; } = new();

        [Inject]
        private IJSRuntime _js { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await ListPedidos();
        }

        private async Task Refresh()
        {
            Request = new();
            await ListPedidos();
        }

        private async Task ListPedidos()
        {
            IsLoading = true;
            try
            {
                var result = await _service.ListAsync(Request);
                if (result!.IsSucess)
                {
                    Response = result.Result;
                    Pager = new()
                    {
                        CurrentPage = Request.Page,
                        TotalPages = result.TotalPages,
                        TotalRows = result.TotalRowsPerPages,
                        RowsPerPage = Request.Rows
                    };
                }
                else
                {
                    Toast.Notify(new(ToastType.Warning, result.Message!));
                }
            }
            catch (Exception ex)
            {
                Toast.Notify(new(ToastType.Danger, ex.Message!));
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task OnPager()
        {
            Request.Page = Pager.CurrentPage;
            Request.Rows = Pager.RowsPerPage;
            await ListPedidos();
        }

        private async Task ExportExcel() 
        {
            IsLoading = true;
            try
            {
                var result = await _service.ExportListAsync(Request);
                var content = result.Result;
                await _js.InvokeVoidAsync("descargarArchivo", "Pedido.xlsx", content.ToArray());
            }
            catch (Exception ex)
            {
                Toast.Notify(new(ToastType.Danger, ex.Message!));
            }
            finally { IsLoading = false; }            
        }
    }
}
