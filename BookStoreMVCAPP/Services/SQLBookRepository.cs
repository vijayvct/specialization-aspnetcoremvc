using BookStoreMVCAPP.Data;
using BookStoreMVCAPP.Models;

namespace BookStoreMVCAPP.Services
{
	public class SQLBookRepository : IBookRepository
	{
		private readonly BookStoreContext context;
        
		public SQLBookRepository(BookStoreContext context)
        {
			this.context = context;
        }

        public Book Create(Book entity)
		{
			context.Books.Add(entity);
			context.SaveChanges();
			return entity;
		}

		public Book Delete(int? id)
		{
			var book = context.Books.Find(id);
			context.Books.Remove(book);
			context.SaveChanges(true);
			return book;
		}

		public Book Get(int? id)
		{
			return context.Books.Find(id);
		}

		public List<Book> GetAll()
		{
			return context.Books.ToList();
		}

		public Book Update(Book entity)
		{
			var updatebook = context.Books.Find(entity.Id);

			updatebook.Title = entity.Title;
			updatebook.Description = entity.Description;
			updatebook.Author = entity.Author;
			updatebook.Language = entity.Language;
			context.SaveChanges();

			return updatebook;
		}
	}
}
