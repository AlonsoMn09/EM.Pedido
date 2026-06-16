using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace EM.Pedido.UI.Common
{
    public abstract class BaseComponent : ComponentBase//REVISAR
    {
        [Inject]
        protected ToastService _toast { get; set; } = default!;
        [Inject]
        protected NavigationManager _navigation { get; set; } = default!;
        [Inject]
        protected PreloadService PreloadService { get; set; } = default!;
    }
}
