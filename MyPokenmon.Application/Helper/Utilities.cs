using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyPokemon.Application.Helper
{
    public static class Utilities
    {
        public static string GenerateSlug(string input)
        {
            input = input.ToLower();
            input = Regex.Replace(input, @"[áàạảãâấầậẩẫăắằặẳẵ]", "a");
            input = Regex.Replace(input, @"[éèẹẻẽêếềệểễ]", "e");
            input = Regex.Replace(input, @"[óòọỏõôốồộổỗơớờợởỡ]", "o");
            input = Regex.Replace(input, @"[íìịỉĩ]", "i");
            input = Regex.Replace(input, @"[ýỳỵỉỹ]", "y");
            input = Regex.Replace(input, @"[úùụủũưứừựửữ]", "u");
            input = Regex.Replace(input, @"[đ]", "d");

            //2. Chỉ cho phép nhận:[0-9a-z-\s]
            input = Regex.Replace(input.Trim(), @"[^0-9a-z-\s]", "").Trim();
            //xử lý nhiều hơn 1 khoảng trắng --> 1 kt
            input = Regex.Replace(input.Trim(), @"\s+", "-");
            //thay khoảng trắng bằng -
            input = Regex.Replace(input, @"\s", "-");
            while (true)
            {
                if (input.IndexOf("--") != -1)
                {
                    input = input.Replace("--", "-");
                }
                else
                {
                    break;
                }
            }
            return input;
        }
    }
}
