
namespace NvkLesson03.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.Rendering;
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }

        //Danh sách các cuốn sách 
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Frieren 1",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/frieren 1.jpg", // Đường dẫn tương đối từ wwwroot
                    Price = 500000,
                    Sumary = "",
                    TotalPage = 250
                },
                new Book()
                {
                    Id = 2,
                    Title = "Frieren 2",
                    AuthorId = 1,
                    GenreId = 2,
                    Image = "/images/products/frieren 2.jpg",
                    Price = 420000,
                    Sumary = "",
                    TotalPage = 220
                },
                new Book()
                {
                    Id = 3,
                    Title = "Frieren 3",
                    AuthorId = 2,
                    GenreId = 3,
                    Image = "/images/products/frieren 3.jpg",
                    Price = 480000,
                    Sumary = "",
                    TotalPage = 300
                }
            };

            return books;
        }
        //chi tiết 1 cuốn sách theo id 
        public Book GetBookById(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }
        // Danh sách tác giả
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Kanehito Yamada" },
            new SelectListItem { Value = "2", Text = "1" },
            new SelectListItem { Value = "3", Text = "Kanehito Yamada" },
            
        };

        // Danh sách thể loại
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Truyện tranh" },
            new SelectListItem { Value = "2", Text = "2" },
            new SelectListItem { Value = "3", Text = "tranh" },
            
        };
    }
}
