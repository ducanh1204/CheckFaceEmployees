using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astec.Common.Ultilities
{
    public static class ConvertFileToBase64
    {
        public static int Imglength;
        public static string ConverFromFileUrl(string url)
        {
            var faceImage = Image.FromFile(url);
            string base64EmImage = ConvertImageToBase64(faceImage);
            return base64EmImage;
        }
        public static string ConvertImageToBase64(Image image)
        {
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, image.RawFormat);
                byte[] imageBytes = m.ToArray();
                var rsByte = ResizeImage(imageBytes);

                string base64String = Convert.ToBase64String(rsByte);
                Imglength = base64String.Length;
                return base64String;
            }
        }
        public static byte[] ResizeImage(byte[] byteImageIn)
        {
            byte[] currentByteImageArray = byteImageIn;
            double scale = 1f;

            MemoryStream inputMemoryStream = new MemoryStream(byteImageIn);
            Image fullsizeImage = Image.FromStream(inputMemoryStream);

            while (currentByteImageArray.Length > 500000)
            {
                Bitmap fullSizeBitmap = new Bitmap(fullsizeImage, new Size((int)(fullsizeImage.Width * scale), (int)(fullsizeImage.Height * scale)));
                MemoryStream resultStream = new MemoryStream();

                fullSizeBitmap.Save(resultStream, fullsizeImage.RawFormat);

                currentByteImageArray = resultStream.ToArray();
                resultStream.Dispose();
                resultStream.Close();

                scale -= 0.05f;
            }

            return currentByteImageArray;
        }


    }
}
