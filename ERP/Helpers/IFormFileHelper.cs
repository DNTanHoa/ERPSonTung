using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ERP.Helpers
{
    public static class IFormFileHelper
    {
        public static bool SaveTo(this IFormFile file, string path)
        {
            try
            {
                //save file to server
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
