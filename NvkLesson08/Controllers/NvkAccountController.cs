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
            NvkAvatar = "avatar1.png",
            NvkBirthday = new DateTime(1990, 5, 20),
            NvkGender = "Nam",
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
            NvkAvatar = "avatar2.png",
            NvkBirthday = new DateTime(1995, 10, 10),
            NvkGender = "Nữ",
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
            NvkAvatar = "avatar3.png",
            NvkBirthday = new DateTime(1988, 3, 15),
            NvkGender = "Nam",
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
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult NvkCreate(NvkAccount Nvkmodel)
        {
            try
            {
                // Tự động sinh mã nếu cần
                if (Nvkmodel.NvkId == 0)
                {
                    Nvkmodel.NvkId = accounts.Max(e => e.NvkId) + 1;
                }
                accounts.Add(Nvkmodel);
                return RedirectToAction(nameof(NvkIndexAccount));
            }
            catch
            {
                return View();
            }
        }

        // GET: NvkAccountController/Edit/5
        public ActionResult NvkEdit(int id)
        {
            var Nvkmodel = accounts.FirstOrDefault(x => x.NvkId == id);
            return View();
        }

        // POST: NvkAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvkEdit(int id, NvkAccount Nvkmodel)
        {
            try
            {
                // cập nhật model vào danh sách 
                for (int i = 0; i < accounts.Count; i++)
                {
                    if (accounts[i].NvkId == id)
                    {
                        accounts[i] = Nvkmodel;
                        break;
                    }
                }
                return RedirectToAction(nameof(NvkIndexAccount));
            }
            catch
            {
                return View();
            }
        }

        // GET: NvkAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NvkAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
