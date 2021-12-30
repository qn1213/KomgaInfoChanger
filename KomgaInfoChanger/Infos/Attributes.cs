using System.Collections.Generic;

namespace KomgaInfoChanger
{    
    public struct SBookAttribute
    {// name = Key
        public string                       id;         // => [id]
        public string                       seriesId;   // => [seriesId]
        public string                       libraryId;  // => [libraryId]
        public string                       mediaType;  // => [media][mediaType]
    }

    public struct SMetaDataAttribute
    {//title;      // => 제목
        public Dictionary<string, string> number;           // => 갤러리 넘버        
        public Dictionary<string, List<string>> atrist;     // => 작가(2명 이상 참여작일 때), Role은 Artist로 하드코딩할 예정
        public Dictionary<string, string> group;            // => 그룹
        public Dictionary<string, string> type;             // => 타입 (동인지, 기타 등등)
        public Dictionary<string, string> series;           // => 시리즈
        public Dictionary<string, List<string>> character;  // => 캐릭터
        public Dictionary<string, List<string>> tag;        // => 태그
        public Dictionary<string, string> language;         // => 언어
    }
}