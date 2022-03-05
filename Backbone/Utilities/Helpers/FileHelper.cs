using Backbone.Utilities.Results;
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

            var result = NewPath(file);
            File.Move(sourcePath, path + result);
            
            return result.Replace("\\", "/");
            //string path = Environment.CurrentDirectory + @"\wwwroot";
            //var sourcePath = Path.GetTempFileName();
            //if (file.Length > 0)
            //{
            //    using (var stream = new FileStream(sourcePath, FileMode.Create))
            //    {
            //        file.CopyTo(stream);
            //    }
            //}

            //var result = NewPath(file); // *
            //File.Move(sourcePath, path + result); // *
            
        }




        public string Update(string sourcePath, IFormFile file)
        {
            string path = Environment.CurrentDirectory + @"\wwwroot";
            var result = NewPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(path + result, FileMode.Create))
                {
                    file.CopyTo(stream);

                }
            }

            File.Delete(path + sourcePath);
            return result.Replace("\\", "/");
        }

        public IResult Delete(string afterpath)
        {
            string path2 = Environment.CurrentDirectory + @"\wwwroot";
            afterpath = afterpath.Replace("/", "\\");
            try
            {
                File.Delete(path2 + afterpath);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);

            }

            return new SuccessResult();
        }

        public static string NewPath(IFormFile formFile)
        {
            FileInfo ff = new FileInfo(formFile.FileName);
            string extension = ff.Extension;

            var newPath = Guid.NewGuid().ToString() + extension;

            return @"\Images\" + newPath;



            //FileInfo fileInfo = new FileInfo(formFile.FileName);
            //string fileExtension = fileInfo.Extension;

            //var newpath = Guid.NewGuid().ToString() + fileExtension;

            //return @"\Images\" + newpath;
        }
    }
}
