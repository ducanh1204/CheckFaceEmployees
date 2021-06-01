using System;
using System.Drawing;
using System.IO;

namespace Astec.Common.Ultilities
{
    public class ConvertBase64stringToImage
    {
        public string SaveImage(string base64,string name)
        {
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;
            string logFilePath = AppDomain.CurrentDomain.BaseDirectory;
            string fname = "ImageQr";
            string date = DateTime.Now.ToString("ddMMyyyy");
            string path = logFilePath + @"\" + fname + @"\" + date;
            string filename = path + @"\" + name.Replace(" ", "") + "_" + date + ".jpg";
           // logFilePath = logFilePath + filename;
            logFileInfo = new FileInfo(filename);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();

            var bytess = Convert.FromBase64String(base64);

            var tr = Resize2Max50Kbytes(bytess);
            using (var imageFile = new FileStream(filename, FileMode.Create))
            {
                imageFile.Write(tr, 0, tr.Length);
                imageFile.Flush();
            }
            return @"\\127.0.0.1\" + fname+"\\"+ date+"\\" + name.Replace(" ", "") + "_" + date + ".jpg"; ;
        }

        public byte[] Resize2Max50Kbytes(byte[] byteImageIn)
        {
            byte[] currentByteImageArray = byteImageIn;
            double scale = 1f;

            MemoryStream inputMemoryStream = new MemoryStream(byteImageIn);
            Image fullsizeImage = Image.FromStream(inputMemoryStream);

            while (currentByteImageArray.Length > 50000)
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