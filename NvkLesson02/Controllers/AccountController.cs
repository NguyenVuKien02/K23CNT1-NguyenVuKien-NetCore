using Microsoft.AspNetCore.Mvc;
using NvkLesson02.Models;

namespace NvkLesson02.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult IndexAc()
        {
            List<Account> accounts = new List<Account>();
            {
                accounts.Add(new Account()
                {
                    Id = 1,
                    Name = "Kien",
                    Email = "nguyenvukien02@gmail.com",
                    Phone = "0379661833",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/13.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2005, 10, 2)
                });

                accounts.Add(new Account()
                {
                    Id = 2,
                    Name = "gg",
                    Email = "nguyenvukien02@gmail.com",
                    Phone = "0379661833",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/14.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2005, 10, 2)
                });

                accounts.Add(new Account()
                {
                    Id = 3,
                    Name = "hh",
                    Email = "nguyenvukien02@gmail.com",
                    Phone = "0379661833",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/15.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2005, 10, 2)
                });

            };
            ViewBag.Accounts = accounts;
            return View();
        }
        [Route("ho-so-cua-toi", Name = "Profile")]
        public IActionResult Profile(int id)
        {
            //Account account = new Account()
            //{
            //    Id = 1,
            //    Name = "Kien",
            //    Email = "nguyenvukien02@gmail.com",
            //    Phone = "0379661833",
            //    Address = "Hà Nội",
            //    Avatar = Url.Content("~/Avatar/13.png"),
            //    Gender = 1,
            //    Bio = "My name is small",
            //    Birthday = new DateTime(2005, 10, 2)
            //};
            List<Account> accounts = new List<Account>();
            {
                accounts.Add(new Account()
                {
                    Id = 1,
                    Name = "Kien",
                    Email = "nguyenvukien02@gmail.com",
                    Phone = "0379661833",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/13.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2005, 10, 2)
                });

                accounts.Add(new Account()
                {
                    Id = 2,
                    Name = "gg",
                    Email = "nguyenvukien02@gmail.com",
                    Phone = "0379661833",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/14.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2005, 10, 2)
                });

                accounts.Add(new Account()
                {
                    Id = 3,
                    Name = "hh",
                    Email = "nguyenvukien02@gmail.com",
                    Phone = "0379661833",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/15.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2005, 10, 2)
                });

            };
            //Sử dụng using Sytem.Linq; truy xuất dữ liệu 1 đối tượng trong danh sách theo id 
            Account account = accounts.FirstOrDefault(ac => ac.Id == id);
            ViewBag.account = account;
            return View();
        }
    }
}
