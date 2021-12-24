namespace KomgaInfoChanger
{    public struct SBookAttribute
    {
        public string id;           // => [id]
        public string seriesId;     // => [seriesId]
        public string libraryId;    // => [libraryId]
        //public string name;         // => [name]
        public string mediaType;    // => [media][mediaType]
    }

    public struct SMetaDataAttribute
    {
        public string number;   // => 갤러리 넘버
        public string title;    // => 제목
        public string[] authors;// => 작가(2명 이상 참여작일 때), Role은 Artist로 하드코딩할 예정
        public string[] tags;   // => 태그
    }
}
