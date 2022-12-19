using Echange_Livres.DTOs;
using Echange_Livres.Repositories;
using Echange_Livres.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Echange_Livres.Controllers
{
    public class LoginController : Controller
    {
        private UserService Uservice = new UserService(new UserRepository());

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDTO loginDTO)
        {
            UserDTO userDTO = Uservice.FindUserByUserNameAndPassword(loginDTO);
            if (userDTO != null && userDTO.Id != 0)
            {

                if (userDTO.IsAdmin)
                {
                    Session["Admin"] = userDTO;
                }
                else
                {
                    Session["user"] = userDTO;
                }
                return RedirectToAction("Home"); //page d'accueil
                //return Content("Page d'accueil.....");
            }
            else
            {
                ViewBag.Erreur = "Echec connexion.......";
            }

            return View(loginDTO);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Home()
        {
            return View(); 
        }
    }
}
