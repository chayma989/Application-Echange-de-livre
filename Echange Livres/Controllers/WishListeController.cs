using Application_Echange_de_livre.Model;
using Echange_Livres.Repositories;
using Echange_Livres.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Echange_Livres.Controllers
{
    public class WishListeController : Controller
    {
        private WishListeService Wservice = new WishListeService(new WishListeRepository(new MyContext()));
        private MyContext context = new MyContext();

        // GET: WishListe
        public ActionResult Index()
        {
            List<WishListe> lstWish = Wservice.GetAll();
            return View(lstWish);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] WishListe wish)
        {
            if (ModelState.IsValid)
            {
                Wservice.Add(wish);
                return RedirectToAction("Index");
            }

            return View(wish);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WishListe wish = context.WishListes.Find(id);

            if (wish == null)
            {
                return HttpNotFound();
            }
            return View(wish);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           WishListe wish = context.WishListes.Find(id);
            Wservice.Delete(wish);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WishListe wish = context.WishListes.Find(id);
            if (wish == null)
            {
                return HttpNotFound();
            }
            return View(wish);
        }

    }
}