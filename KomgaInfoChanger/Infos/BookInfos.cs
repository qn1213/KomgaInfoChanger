using System.Collections.Concurrent;

namespace KomgaInfoChanger.Infos
{
    // 클라이언트의 zip파일 정보 받아오는 클래스

    internal class BookInfos
    {
        // <File Name, Info>
        private ConcurrentDictionary<string, SBookAttribute> books;

        public BookInfos()
        {
            books = new ConcurrentDictionary<string, SBookAttribute>();
        }

        public ConcurrentDictionary<string, SBookAttribute> GetBooks()
        {
            return books;
        }

        // _name => File Name(Without .zip)
        public bool AddBook(string _name, SBookAttribute attribute)
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
