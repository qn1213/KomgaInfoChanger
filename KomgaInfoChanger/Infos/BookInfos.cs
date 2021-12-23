using System.Collections.Concurrent;

namespace KomgaInfoChanger.Infos
{
    // 서버 -> 클라이언트 : 북 정보 받아오는 클래스
    public struct SAttribute
    {
        public string id;           // => [id]
        public string seriesId;     // => [seriesId]
        public string libraryId;    // => [libraryId]
        //public string name;         // => [name]
        public string mediaType;    // => [media][mediaType]
    }
    internal class BookInfos
    {
        // <File Name, Info>
        private ConcurrentDictionary<string, SAttribute> books;

        public BookInfos()
        {
            books = new ConcurrentDictionary<string, SAttribute>();
        }

        public ConcurrentDictionary<string, SAttribute> GetBooks()
        {
            return books;
        }

        // _name => File Name(Without .zip)
        public bool AddBook(string _name, SAttribute attribute)
        {
            if(books == null || !books.ContainsKey(_name))
            {
                books.TryAdd(_name, attribute);
                return true;
            }
            else return false;            
        }
    }
}
