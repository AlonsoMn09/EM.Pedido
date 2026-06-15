using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.DTO.Request
{
    public class PagerRequest
    {
        public int CurrentPage { get; set; }
        public int RowsPerPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }
    }
}
