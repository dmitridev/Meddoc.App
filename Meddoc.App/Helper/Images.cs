using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace Meddoc.App.Helper
{
    public static class Images
    {
        public static BitmapSource Load(byte[] bytes)
        {
            MemoryStream byteStream = new MemoryStream(bytes);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            return image;
        }

        public static BitmapSource Load(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            return Load(bytes);
        }

        public static string ToBase64String(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

    }
}
