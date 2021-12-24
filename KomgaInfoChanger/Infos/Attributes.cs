using System.Collections.Generic;

namespace KomgaInfoChanger
{    public struct SBookAttribute
    {// name = Key
        public string                       id;         // => [id]
        public string                       seriesId;   // => [seriesId]
        public string                       libraryId;  // => [libraryId]
        public string                       mediaType;  // => [media][mediaType]
    }

    public struct SMetaDataAttribute
    {
        public string                       number;     // => 갤러리 넘버
        public string                       title;      // => 제목
        public string[]                     atrist;     // => 작가(2명 이상 참여작일 때), Role은 Artist로 하드코딩할 예정
        public string[]                     group;      // => 그룹
        public string                       type;       // => 타입 (동인지, 기타 등등)
        public string[]                       series;     // => 시리즈
        public string[]                     character;  // => 캐릭터
        public Dictionary<string, string>   tag;        // => 태그
        public string                       language;   // => 언어
    }
}
