using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Backbone.Utilities.Helpers
{
    public class FileHelper:IFileHelper
    {
        public string Add(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public string Update(string sourcePath, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public string Delete(string path)
        {
            throw new NotImplementedException();
        }
    }
}
