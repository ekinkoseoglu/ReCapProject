using Backbone.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Backbone.Utilities.Helpers
{
    public interface IFileHelper
    {
        public string Add(IFormFile file);
        public string Update(string sourcePath, IFormFile file);
        public IResult Delete(string path);
    }
}
