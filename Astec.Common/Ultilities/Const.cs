using System.Configuration;

namespace Astec.Common.Ultilities
{
    public static class Const
    {
        public static string ZONES_ID { get; set; }
        public static string ZONES_CODE { get; set; }
        public static string ZONES_NAME { get; set; }
        public static int? ACC_ID { get; set; }
        public static string CONN_STRING = ConfigurationManager.ConnectionStrings["AstecConnection"].ConnectionString;
        public static string USER_NAME { get; set; }
        public static string EM_NAME { get; set; }
        public static string UserId { get; set; }
        public static string NAME { get; set; }

        //SCHEDULE
        public const int SUN_DAY = 0;
        public const int MON_DAY = 1;
        public const int TUE_DAY = 2;
        public const int WED_DAY = 3;
        public const int THU_DAY = 4;
        public const int FRI_DAY = 5;
        public const int SAT_DAY = 6;

        //RESULT_CHECK
        public const int RESULT_CHECK_NGHI = 0;
        public const int RESULT_CHECK_DI_LAM_BINH_THUONG = 1;
        public const int RESULT_CHECK_KHAC = 2;
        public const int RESULT_CHECK_NGHI_PHEP = 3;
        public const int RESULT_CHECK_NGHI_PHEP_KHONG_LUONG = 4;
        //LEAVE
        public const int CA_SANG = 1;
        public const int CA_CHIEU = 2;
        public const int CA_NGAY = 3;

        //TimeAttendance RESULT
        public const string RESULT_CHAM_DUNG_GIO = "OK";
        public const string RESULT_KHONG_CHAM_CONG = "NO";
        public const string RESULT_NGHI_PHEP = "NP";
        public const string RESULT_NGHI_PHEP_KHONG_LUONG = "NPKL";

        //TimeAttendance RESULT_ALL
        public const string RESULT_ALL_DI_LAM_BINH_THUONG = "Đi làm bình thường";
        public const string RESULT_ALL_NGHI = "Nghỉ";
        public const string RESULT_ALL_KHONG_CHAM_DU_CONG = "Không chấm đủ công";
        public const string RESULT_ALL_NGHI_PHEP = "NP";
        public const string RESULT_ALL_NGHI_PHEP_KHONG_LUONG = "NPKL";
        public const string RESULT_ALL_CONG_TAC_NGOAI_SANG = "Công tác ngoài sáng";
        public const string RESULT_ALL_CONG_TAC_NGOAI_CHIEU = " Công tác ngoài chiều";
        public const string RESULT_ALL_CONG_TAC_NGOAI = "Công tác ngoài";

        public const string SANG = "Sáng";
        public const string CHIEU = "Chiều";
        public const string CANGAY = "Cả ngày";

        //Hiếu
        public static int FINGERPRINT_TIME_ATTENDANCY_CHECK = 1;
        public static int FINGERPRINT_AND_CARD_TIME_ATTENDANCY_CHECK = 2;
        public static int CARD_TIME_ATTENDANCY_CHECK = 3;
    }
}
