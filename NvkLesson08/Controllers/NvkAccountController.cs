using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NvkLesson08.Models;
using System.Reflection;
using System.Security.Principal;

namespace NvkLesson08.Controllers
{
    public class NvkAccountController : Controller
    {
        private static List<NvkAccount> accounts = new List<NvkAccount>()
        {
        new NvkAccount
        {
            NvkId = 1,
            NvkFullName = "Nguyễn Văn A",
            NvkEmail = "vana@example.com",
            NvkPhone = "0986421127",
            NvkAddress = "Hà Nội",
            NvkAvatar = "frieren 1.jpg",
            NvkBirthday = new DateTime(1990, 5, 20),
            NvkGender = 1,
            NvkPassword = "password1",
            NvkFacebook = "https://facebook.com/vana"
        },
        new NvkAccount
        {
            NvkId = 2,
            NvkFullName = "Trần Thị B",
            NvkEmail = "thib@example.com",
            NvkPhone = "0981234567",
            NvkAddress = "Đà Nẵng",
            NvkAvatar = "frieren 1.jpg",
            NvkBirthday = new DateTime(1995, 10, 10),
            NvkGender = 2,
            NvkPassword = "password2",
            NvkFacebook = "https://facebook.com/thib"
        },
        new NvkAccount
        {
            NvkId = 3,
            NvkFullName = "Lê Văn C",
            NvkEmail = "vanc@example.com",
            NvkPhone = "0977654321",
            NvkAddress = "TP.HCM",
            NvkAvatar = "frieren 1.jpg",
            NvkBirthday = new DateTime(1988, 3, 15),
            NvkGender = 1,
            NvkPassword = "password3",
            NvkFacebook = "https://facebook.com/vanc"
        }
    };
// GET: NvkAccountController
        public ActionResult NvkIndexAccount()
        {
            
            return View(accounts);
        }

        // GET: NvkAccountController/Details/5
        public ActionResult NvkDetails(int id)
        {
            var Nvkmodel = accounts.FirstOrDefault(e => e.NvkId == id);
            if (Nvkmodel == null)
            {
                return NotFound();
            }
            return View(Nvkmodel);
        }

        // GET: NvkAccountController/Create
        public ActionResult NvkCreate()
        {
            NvkAccount Nvkmodel = new NvkAccount();
            return View(Nvkmodel);
        }

        // POST: NvkAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvkCreate(NvkAccount Nvkmodel, IFormFile NvkAvatarFile)
        {
            try
            {
                // Xử lý upload ảnh
                if (NvkAvatarFile != null && NvkAvatarFile.Length > 0)
                {
                    // Lấy tên file gốc
                    var fileName = Path.GetFileName(NvkAvatarFile.FileName);

                    // Tạo đường dẫn lưu ảnh vào thư mục wwwroot/images
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    // Ghi file ảnh vào thư mục
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        NvkAvatarFile.CopyTo(stream);
                    }

                    // Gán tên file vào thuộc tính Avatar trong model
                    Nvkmodel.NvkAvatar = fileName;
                }

                // Sinh mã ID tự động
                if (Nvkmodel.NvkId == 0)
                {
                    Nvkmodel.NvkId = accounts.Any() ? accounts.Max(e => e.NvkId) + 1 : 1;
                }

                // Lưu vào danh sách tạm
                accounts.Add(Nvkmodel);

                return RedirectToAction(nameof(NvkIndexAccount));
            }
            catch
            {
                return View(Nvkmodel);
            }
        }

        // GET: NvkAccountController/Edit/5
        public ActionResult NvkEdit(int id)
        {
            var Nvkmodel = accounts.FirstOrDefault(x => x.NvkId == id);
            
            return View(Nvkmodel); // Truyền dữ liệu vào view
        }

        // POST: NvkAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvkEdit(int id, NvkAccount Nvkmodel, IFormFile NvkAvatarFile)
        {
            try
            {
                var existing = accounts.FirstOrDefault(a => a.NvkId == id);
                if (existing != null)
                {
                    // Cập nhật từng trường nếu cần
                    existing.NvkFullName = Nvkmodel.NvkFullName;
                    existing.NvkEmail = Nvkmodel.NvkEmail;
                    existing.NvkPhone = Nvkmodel.NvkPhone;
                    existing.NvkAddress = Nvkmodel.NvkAddress;
                    if (NvkAvatarFile != null && NvkAvatarFile.Length > 0)
                    {
                        var fileName = Path.GetFileName(NvkAvatarFile.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            NvkAvatarFile.CopyTo(stream);
                        }

                        existing.NvkAvatar = fileName;
                    }
                    existing.NvkBirthday = Nvkmodel.NvkBirthday;
                    existing.NvkGender = Nvkmodel.NvkGender;
                    existing.NvkPassword = Nvkmodel.NvkPassword;
                    existing.NvkFacebook = Nvkmodel.NvkFacebook;
                }
                return RedirectToAction(nameof(NvkIndexAccount));
            }
            catch
            {
                return View(Nvkmodel); // Trả lại model khi có lỗi
            }
        }

        // GET: NvkAccountController/Delete/5
        public ActionResult NvkDelete(int id)
        {
            var employee = accounts.FirstOrDefault(e => e.NvkId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: NvkAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvkDelete(int id, IFormCollection collection)
        {
            try
            {
                var employee = accounts.FirstOrDefault(e => e.NvkId == id);
                if (employee != null)
                {
                    accounts.Remove(employee);
                }
                return RedirectToAction(nameof(NvkIndexAccount));
            }
            catch
            {
                return View();
            }
        }
    }
}
