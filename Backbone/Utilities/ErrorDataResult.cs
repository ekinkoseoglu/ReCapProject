using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backbone.Utilities
{
    public class ErrorDataResult<T>:DataResult<T>,IResult
    {
        public ErrorDataResult(T data, bool success, string message) : base(data, false, message)
        {
        }

        public ErrorDataResult(T data, bool success) : base(data, false)
        {
        }

        public ErrorDataResult(string message):base(default, false,message)
        {
            
        }

        public ErrorDataResult():base(default,false)
        {
            
        }
    }
}
