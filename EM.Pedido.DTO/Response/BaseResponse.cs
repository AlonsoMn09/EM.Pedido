using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Pedido.DTO.Response
{
    public class BaseResponse
    {
        public string? Message { get; set; }
        public string? ErrorCode { get; set; }
        public bool IsSucess { get; set; }
    }

    public class BaseResponse<T> : BaseResponse
    {
        public T? Result { get; set; }
    }

    public class PagedResponse<T> : BaseResponse
    {
        public ICollection<T> Result { get; set; } = new List<T>();
        public int TotalPages { get; set; }
        public int TotalRowsPerPages { get; set; }
    }
}
