using BookStoreMVCAPP.Models;

namespace BookStoreMVCAPP.Services
{
    public class MockBookRepository : IBookRepository
    {
        private List<Book> list;

        public MockBookRepository() 
        {
            list = new List<Book>()
            {
                new Book{Id=1,Title="Asp.NET Core MVC",Author="Scott Hanselman",Description="Book on Asp.NET Core",Language=Language.English},
                 new Book{Id=2,Title="SQL Server 2019",Author="Malcolm D",Description="Book on SQL Server",Language=Language.English}
            };

        }

        public Book Create(Book entity)
        {
            var id = list.Max(x => x.Id) + 1;
            entity.Id = id;
            list.Add(entity);
            return entity;
        }

        public Book Delete(int? id)
        {
            var book = list.Find(x => x.Id == id);
            list.Remove(book);
            return book;
        }

        public Book Get(int? id)
        {
            return list.Find(x=>x.Id==id);
        }

        public List<Book> GetAll()
        {
            return list;
        }

        public Book Update(Book entity)
        {
            var updateBook = list.Find(b => b.Id == entity.Id);

            updateBook.Title = entity.Title;
            updateBook.Author = entity.Author;
            updateBook.Description = entity.Description;
            updateBook.Language = entity.Language;

            return updateBook;
        }
    }
}
