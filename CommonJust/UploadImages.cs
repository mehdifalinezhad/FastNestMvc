
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace CommonJust
{
    public static class UploadImages
    {
        public static string SaveImage(IFormFile file, string DirectoryName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + @"\wwwroot" + @$"\{DirectoryName}\");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string SaveName = Guid.NewGuid().ToString() + file.FileName;
            var SavedUrl = $"/{DirectoryName}/{SaveName}";
            var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", DirectoryName)).Root + $@"\{SaveName}";

            using (FileStream fs = File.Create(filepath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }

            return SavedUrl;
        }

    }
    }

