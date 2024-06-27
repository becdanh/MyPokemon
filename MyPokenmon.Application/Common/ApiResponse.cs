using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPokemon.Application.Common
{
    public class ApiResponse<T>
    {
        public T Result { get; set; }
        public bool Success { get; set; }
        public ApiError Error { get; set; }
    }
    public class ApiError
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
    }

    public class ItemResult<T>
    {
        public T Item { get; set; }
    }

}
