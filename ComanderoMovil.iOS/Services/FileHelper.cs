using System;
using Xamarin.Forms;
using ComanderoMovil.iOS.Services;
using ComanderoMovil.Services;
using System.IO;

[assembly:Dependency(typeof(FileHelper))]
namespace ComanderoMovil.iOS.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            var docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "Database");
            if(!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}
