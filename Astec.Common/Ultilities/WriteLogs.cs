using System;
using System.IO;

namespace Astec.Common.Ultilities
{
    public static class WriteLogs
    {
        //public static void WriteLog(string strLog)
        //{
        //    StreamWriter log;
        //    FileStream fileStream = null;
        //    DirectoryInfo logDirInfo = null;
        //    FileInfo logFileInfo;

        //    //SetMemoEditText(strLog);

        //    string logFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\";
        //    logFilePath = logFilePath + "Log" + "." + "txt";
        //    logFileInfo = new FileInfo(logFilePath);
        //    logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
        //    if (!logDirInfo.Exists) logDirInfo.Create();
        //    if (!logFileInfo.Exists)
        //    {
        //        fileStream = logFileInfo.Create();
        //    }
        //    else
        //    {
        //        fileStream = new FileStream(logFilePath, FileMode.Append);
        //    }
        //    log = new StreamWriter(fileStream);
        //    log.WriteLine(strLog);
        //    log.Close();
        //}

        public static void WriteLog(string strLog, string type)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            //SetMemoEditText(strLog);

            string logFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\SyncUNVFaceLogs\\" + "\\"+type+"\\";
            logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.WriteLine(strLog);
            log.Close();
        }
    }
}