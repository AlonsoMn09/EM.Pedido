using Microsoft.AspNetCore.Components;

namespace EM.Pedido.UI.Components.Shared
{
    public partial class GroupBox
    {
        [Parameter]
        public string Titulo { get; set; } = default!;

        [Parameter]
        public RenderFragment Content { get; set; } = default!;

        [Parameter]
        public string Class { get; set; } = default!;
    }
}
