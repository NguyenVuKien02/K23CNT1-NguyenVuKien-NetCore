using Microsoft.AspNetCore.Mvc;
using NvkLesson07.Models;

namespace NvkLesson07.Controllers
{
    public class NvkEmployeeController : Controller
    {
        public static readonly List<NvkEmployee> nvkEmployee = new List<NvkEmployee>()
        {
            new NvkEmployee {  NvkName = "Kien", NvkBirthDay = new DateTime(2005, 10, 2), NvkEmail = "nguyenvukien02@gmail.com", NvkPhone = "0379661833", NvkSalary = "1000", NvkStatus = 1 },
            new NvkEmployee {  NvkName = "member2", NvkBirthDay = new DateTime(2005, 10, 2) , NvkEmail = "nguyenvukien03@gmail.com", NvkPhone = "0359661833", NvkSalary = "1000", NvkStatus = 2 },
            new NvkEmployee {  NvkName = "member3", NvkBirthDay = new DateTime(2005, 10, 2), NvkEmail = "nguyenvukien04@gmail.com", NvkPhone = "0374661833", NvkSalary = "1000", NvkStatus = 1 },
            new NvkEmployee {  NvkName = "member4", NvkBirthDay = new DateTime(2005, 10, 2), NvkEmail = "nguyenvukien05@gmail.com", NvkPhone = "0179661833", NvkSalary = "1000", NvkStatus = 1 },
            new NvkEmployee {  NvkName = "member5", NvkBirthDay = new DateTime(2005, 10, 2), NvkEmail = "nguyenvukien06@gmail.com", NvkPhone = "0123618339", NvkSalary = "1000", NvkStatus = 2 }
        };

        public IActionResult NvkIndex1()
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
            //// Gán mã MemberId mới (kiểu Guid)
            //employee.NvkId = Guid.NewGuid().ToString();

            // Thêm đối tượng member vào danh sách
            nvkEmployee.Add(employee);

            // Chuyển hướng về trang danh sách thành viên
            return RedirectToAction("NvkIndex1");
        }
        //  GET: /TvcEmployee/TvcEdit/id?
        public IActionResult NvkEdit(int id)
        {
            var model = nvkEmployee.FirstOrDefault(x => x.NvkId == id);
            return View(model);
        }
        [HttpPost]
        public IActionResult NvkEdit(NvkEmployee employee)
        {
            var existing = nvkEmployee.FirstOrDefault(x => x.NvkId == employee.NvkId);
            if (existing != null)
            {
                existing.NvkName = employee.NvkName;
                existing.NvkBirthDay = employee.NvkBirthDay;
                existing.NvkEmail = employee.NvkEmail;
                existing.NvkPhone = employee.NvkPhone;
                existing.NvkSalary = employee.NvkSalary;
                existing.NvkStatus = employee.NvkStatus;
            }

            return RedirectToAction("NvkIndex1");
        }

        public IActionResult NvkDetails(int id)
        {
            var employee = nvkEmployee.FirstOrDefault(e => e.NvkId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        // GET: Hiển thị xác nhận xóa
        public IActionResult NvkDelete(int id)
        {
            var employee = nvkEmployee.FirstOrDefault(e => e.NvkId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Xóa nhân viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NvkDelete(int id, IFormCollection collection)
        {
            try
            {
                var employee = nvkEmployee.FirstOrDefault(e => e.NvkId == id);
                if (employee != null)
                {
                    nvkEmployee.Remove(employee);
                }
                return RedirectToAction(nameof(NvkIndex1));
            }
            catch
            {
                return View();
            }
        }
    }
}