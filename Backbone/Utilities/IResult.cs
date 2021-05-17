using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backbone.Utilities
{
   public interface IResult
    {
        public bool Success { get; }
        public string Message { get; }
    }
}
