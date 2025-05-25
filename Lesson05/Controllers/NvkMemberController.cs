using Lesson05.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace Lesson05.Controllers
{
    public class NvkMemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

            //var nvkMember = new NvkMember();
            //nvkMember.NvkMemberId = Guid.NewGuid().ToString();
            //nvkMember.NvkUserName = "Kien";
            //nvkMember.NvkFullName = "Nguyen Vu Kien";
            //nvkMember.NvkPassword = "123456aA";
            //nvkMember.NvkEmail = "nguyenvukien@gmail.com";
            public static readonly List<NvkMember> nvkMember = new List<NvkMember>()
            {
                new NvkMember { NvkMemberId = Guid.NewGuid().ToString(), NvkUserName = "member1", NvkFullName = "Thành viên 1", NvkPassword = "123456", NvkEmail = "tv1@gmail.com" },
                new NvkMember { NvkMemberId = Guid.NewGuid().ToString(), NvkUserName = "member2", NvkFullName = "Thành viên 2", NvkPassword = "123456", NvkEmail = "tv2@gmail.com" },
                new NvkMember { NvkMemberId = Guid.NewGuid().ToString(), NvkUserName = "member3", NvkFullName = "Thành viên 3", NvkPassword = "123456", NvkEmail = "tv3@gmail.com" },
                new NvkMember { NvkMemberId = Guid.NewGuid().ToString(), NvkUserName = "member4", NvkFullName = "Thành viên 4", NvkPassword = "123456", NvkEmail = "tv4@gmail.com" },
                new NvkMember { NvkMemberId = Guid.NewGuid().ToString(), NvkUserName = "member5", NvkFullName = "Thành viên 5", NvkPassword = "123456", NvkEmail = "tv5@gmail.com" }
            };

        public IActionResult NvkGetMember()
        {
            ViewBag.nvkMember = nvkMember;
            return View();
        }
        public IActionResult NvkCreate()
        {
            return View();
        }
        [HttpPost] // hành động gọi ứng với method là POST
        public IActionResult Create(NvkMember member)
        {
            // Gán mã MemberId mới (kiểu Guid)
            member.NvkMemberId = Guid.NewGuid().ToString();

            // Thêm đối tượng member vào danh sách
            nvkMember.Add(member);

            // Chuyển hướng về trang danh sách thành viên
            return RedirectToAction("NvkGetMember");
        }

    }
}
