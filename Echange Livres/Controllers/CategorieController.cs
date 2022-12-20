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
    public class CategorieController : Controller
    {
        private CategorieService catService = new CategorieService(new CategorieRepository());
        private MyContext context = new MyContext();

        // GET: Categorie
        public ActionResult Index()
        {
            List<Categorie> lstcat = catService.GetAll();
            return View(lstcat);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name")] Categorie cat)
        {
            if (ModelState.IsValid)
            {
                catService.Add(cat);
                return RedirectToAction("Index");
            }

            return View(cat);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie cat = context.Categories.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categorie cat = context.Categories.Find(id);
            catService.Delete(cat);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie cat = context.Categories.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Categorie cat)
        {
            if (ModelState.IsValid)
            {
                catService.Update(cat);
                return RedirectToAction("Index");
            }
            return View(cat);
        }


    }
}