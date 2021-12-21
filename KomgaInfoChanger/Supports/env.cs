namespace KomgaInfoChanger
{
    internal class env
    {
        // 로그파일 경로
        public static string logPath {get; set;}

        // 서버 정보
        public static string serverAddr { get; set; }
        public static string serverPW { get; set; }


        // 로그인 정보
        public static string basicAuthInfo { get; set; }





        // 상수
        public const string AUTH_PREFIX_ = "Basic ";
    }
}
