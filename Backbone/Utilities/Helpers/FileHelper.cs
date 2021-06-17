using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Backbone.Utilities.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string Add(IFormFile file)
        {
            string path = Environment.CurrentDirectory + @"\wwwroot";
            var sourcePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            var result = NewPath(file); // *
            File.Move(sourcePath, path + result); // *
            return result.Replace("\\", "/");
        }

        public string Update(string sourcePath, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public string Delete(string path)
        {
            throw new NotImplementedException();
        }

        public static string NewPath(IFormFile formFile)
        {
            FileInfo fileInfo = new FileInfo(formFile.FileName);
            string fileExtension = fileInfo.Extension;

            var newpath = Guid.NewGuid().ToString() + fileExtension;

            return @"\Images\" + newpath;
        }
    }
}
