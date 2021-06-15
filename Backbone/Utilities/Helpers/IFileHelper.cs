using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Backbone.Utilities.Helpers
{
   public interface IFileHelper
   {
       public  string Add(IFormFile file);
       public  string Update(string sourcePath, IFormFile file);
       public  string Delete(string path);
   }
}
