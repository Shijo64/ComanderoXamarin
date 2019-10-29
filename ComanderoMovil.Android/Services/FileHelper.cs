using System;
using ComanderoMovil.Droid.Services;
using ComanderoMovil.Services;
using Xamarin.Forms;
using System.IO;

[assembly:Dependency(typeof(FileHelper))]
namespace ComanderoMovil.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
