using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.DTO.Request
{
    public class SearchListRequest : PagedRequest
    {
        public string? Filter { get; set; }
    }
}
