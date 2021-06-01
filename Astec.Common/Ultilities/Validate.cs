using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Astec.Common.Ultilities
{
    public class Validate
    {
        public string GetMD5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in bHash)
            {
                sbHash.Append(String.Format("{0:x2}", b));
            }

            return sbHash.ToString();
        }
        public int DayToScheCode(string day)
        {
            int scheCode = 0;
            switch (day)
            {
                case "SUNDAY":
                    scheCode = 0;
                    break;
                case "MONDAY":
                    scheCode = 1;
                    break;
                case "TUESDAY":
                    scheCode = 2;
                    break;
                case "WEDNESDAY":
                    scheCode = 3;
                    break;
                case "THURSDAY":
                    scheCode = 4;
                    break;
                case "FRIDAY":
                    scheCode = 5;
                    break;
                case "SATURDAY":
                    scheCode = 6;
                    break;
            }
            return scheCode;
        }
        public string ScheCodeToDay(int sche_Code)
        {
            string day = "";
            switch (sche_Code)
            {
                case 0:
                    day = "Chủ nhật";
                    break;
                case 1:
                    day = "Thứ 2";
                    break;
                case 2:
                    day = "Thứ 3";
                    break;
                case 3:
                    day = "Thứ 4";
                    break;
                case 4:
                    day = "Thứ 5";
                    break;
                case 5:
                    day = "Thứ 6";
                    break;
                case 6:
                    day = "Thứ 7";
                    break;
            }
            return day;
        }
    }
}
