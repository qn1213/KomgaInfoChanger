namespace KomgaInfoChanger
{
    internal static class env
    {
        // 로그파일 경로
        public static string logPath {get; set;}

        public static ServerInfo info;
        internal struct ServerInfo
        {
            public string serverAddr { get; set; }
            public string serverID { get; set; }
            public string serverPW { get; set; }
        }

        // 요청 정보
        public const string AUTH_PREFIX_ = "Authorization";
        
        // 로그인 정보
        public static string basicAuthInfo { get; set; }               


        // 파일

        // 작품 메타데이터 info.txt파일 이름
        public static string infoName { get; set; }



    }
}
