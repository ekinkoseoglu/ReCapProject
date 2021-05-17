using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backbone.Utilities
{
    public class ErrorDataResult<T>:DataResult<T>,IResult
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
            // Hem data hem mesaj girmek için
        }

        public ErrorDataResult(T data) : base(data, false)
        {
            // sadece data girmek için
        }

        public ErrorDataResult(string message):base(default,false,message)
        {
            // sadece mesaj girmek için (Nadir)
        }

        public ErrorDataResult():base(default,false)// Bir üsttekinin mesaj vermeyen hali
        {
            // Hiçbir parametre girmene gerek yok (Nadir)
        }
    }
}
