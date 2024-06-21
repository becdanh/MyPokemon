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
        public string Message { get; set; }
        public string Details { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }
    }

    public class ValidationError
    {
        public string Field { get; set; }
        public string Error { get; set; }
    }

}
