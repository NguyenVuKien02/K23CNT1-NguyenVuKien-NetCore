using Microsoft.AspNetCore.Mvc;
using NvkLab06.Models;

namespace NvkLab06.Controllers
{
    public class NvkEmployeeController : Controller
    {
        public static readonly List<NvkEmployee> nvkEmployee = new List<NvkEmployee>()
        {
            new NvkEmployee { NvkId = Guid.NewGuid().ToString(), NvkName = "Kien", NvkBirthDay = new DateTime(2005, 10, 2), NvkEmail = "nguyenvukien02@gmail.com", NvkPhone = "0379661833", NvkSalary = "1000", NvkStatus = 1 },
            new NvkEmployee { NvkId = Guid.NewGuid().ToString(), NvkName = "member2", NvkBirthDay = new DateTime(2005, 10, 2) , NvkEmail = "nguyenvukien03@gmail.com", NvkPhone = "0359661833", NvkSalary = "1000", NvkStatus = 2 },
            new NvkEmployee { NvkId = Guid.NewGuid().ToString(), NvkName = "member3", NvkBirthDay = new DateTime(2005, 10, 2), NvkEmail = "nguyenvukien04@gmail.com", NvkPhone = "0374661833", NvkSalary = "1000", NvkStatus = 1 },
            new NvkEmployee { NvkId = Guid.NewGuid().ToString(), NvkName = "member4", NvkBirthDay = new DateTime(2005, 10, 2), NvkEmail = "nguyenvukien05@gmail.com", NvkPhone = "0179661833", NvkSalary = "1000", NvkStatus = 1 },
            new NvkEmployee { NvkId = Guid.NewGuid().ToString(), NvkName = "member5", NvkBirthDay = new DateTime(2005, 10, 2), NvkEmail = "nguyenvukien06@gmail.com", NvkPhone = "0123618339", NvkSalary = "1000", NvkStatus = 2 }
        };

        public IActionResult NvkIndex()
        {
            ViewBag.nvkEmployee = nvkEmployee;
            return View();
        }
        public IActionResult NvkCreate()
        {
            return View();
        }
        [HttpPost] // hành động gọi ứng với method là POST
        public IActionResult NvkCreateSubmit(NvkEmployee employee)
        {
            // Gán mã MemberId mới (kiểu Guid)
            employee.NvkId = Guid.NewGuid().ToString();

            // Thêm đối tượng member vào danh sách
            nvkEmployee.Add(employee);

            // Chuyển hướng về trang danh sách thành viên
            return RedirectToAction("NvkIndex");
        }

    }
}
