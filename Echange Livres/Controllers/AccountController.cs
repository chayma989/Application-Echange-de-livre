using Echange_Livres.DTOs;
using Echange_Livres.Repositories;
using Echange_Livres.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Echange_Livres.Controllers
{
    public class AccountController : Controller
    {
        private UserService Uservice = new UserService(new UserRepository());
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserDTO userDto, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                userDto.Photo = userDto.Email + Path.GetExtension(photo.FileName);
                photo.SaveAs(Server.MapPath("~/Content/UserImages/") + userDto.Photo);
                Uservice.Add(userDto);
                return RedirectToAction("Index", "Login");
            }
            return View(userDto);
        }


    }
}