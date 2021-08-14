using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Models
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Books.Any()) return;

            var books = new List<Book>
            {
                new Book
                {
                    Title = "Book title 1",
                    Author = "Book author 1",
                    Category = "Book category 11"
                },
                new Book
                {
                    Title = "Book title 2",
                    Author = "Book author 2",
                    Category = "Book category 2"
                },
                new Book
                {
                    Title = "Book title 3",
                    Author = "Book author 3",
                    Category = "Book category 3"
                }
            };
            await context.Books.AddRangeAsync(books);
            await context.SaveChangesAsync();
        }
    }
}