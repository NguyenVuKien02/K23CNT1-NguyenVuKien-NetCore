using Microsoft.AspNetCore.Mvc;
using NvkLesson03.Models;

namespace NvkLesson03.Controllers
{
    public class BookController : Controller
    {
        // Khởi tạo lớp Book để sử dụng các dữ liệu mẫu
        protected Book book = new Book();
        public IActionResult IndexBook()
        {
            // Truyền dữ liệu SelectListItem cho dropdown
            ViewBag.authors = book.Authors; // danh sách tác giả
            ViewBag.genres = book.Genres;   // danh sách thể loại

            // Lấy danh sách sách
            var books = book.GetBookList();

            // Trả dữ liệu về view
            return View(books);
        }
        public IActionResult Create()
        {
            ViewBag.authors = book.Authors;//Truyền dữ liệu SelectListItem qua view
            ViewBag.genres = book.Genres;
            Book model = new Book();
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.authors = book.Authors;//Truyền dữ liệu SelectListItem qua view
            ViewBag.genres = book.Genres;
            Book model = book.GetBookById(id);
            return View(model);
        }
    }
}
