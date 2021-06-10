using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backbone.Utilities.Results
{
   public interface IDataResult<T>:IResult
    {
        public T Data { get; }
    }
}
