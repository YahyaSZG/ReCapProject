using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperForLocalStroge
    {
        public static void Add(IFormFile file, string path)
        {
            if (file.Length > 0)
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }
            }
        }

        public static void Delete(string pathToDelete)
        {
            if (File.Exists(pathToDelete))
            {
                File.Delete(pathToDelete);
            }
        }

        public static void Update(IFormFile fileForUpdate, string oldPath, string newPath)
        {
            if (newPath != null)
            {
                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    fileForUpdate.CopyTo(stream);
                    stream.Flush();
                }
                File.Delete(oldPath);
            }
        }
    }
}
