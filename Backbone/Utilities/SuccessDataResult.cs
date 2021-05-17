using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backbone.Utilities
{
    public class SuccessDataResult<T>:DataResult<T>,IResult
    {
        public SuccessDataResult(T data,  string message) : base(data, true, message)
        {
            // Hem data hem mesaj girmek için
        }

        public SuccessDataResult(T data) : base(data, true)
        {
            // sadece data girmek için
        }

        public SuccessDataResult(string message):base(default,true,message)
        {
            // sadece mesaj girmek için (Nadir)
        }

        public SuccessDataResult() : base(default, true) // Bir üsttekinin mesaj vermeyen hali
        {
            // Hiçbir parametre girmene gerek yok (Nadir)
        }
    }
}
