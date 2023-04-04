using BookStoreMVCAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreMVCAPP.Data
{
	public class BookStoreContext:DbContext
	{
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            :base(options)
        {
         
        }

        public DbSet<Book> Books { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Book>().HasData
				(
					new Book { Id=1,Title="Sql Server 2019",Author="Malcolm",Description="Book on SqlServer",Language=Language.English},
					new Book { Id=2,Title="AZ-900 Azure Fundamentals",Author="James",Description="Book on Azure Certification",Language=Language.English},
					new Book { Id=3,Title="Japanese way of living",Author="Mark",Description="Cultural Book",Language=Language.Japaneses}
				);
		}
	}
}
