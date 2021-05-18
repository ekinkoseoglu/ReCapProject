using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backbone.Utilities
{
    public class SuccessDataResult<T>:DataResult<T>,IResult
    {
        public SuccessDataResult(T data, bool success, string message) : base(data, true, message)
        {
        }

        public SuccessDataResult(T data, bool success) : base(data, true)
        {
        }

        public SuccessDataResult(string message):base(default,true,message)
        {
            
        }

        public SuccessDataResult():base(default,true)
        {
            
        }
    }
}
