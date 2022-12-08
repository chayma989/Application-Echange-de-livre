using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Echange_Livres.DTOs;
using Echange_Livres.Repositories;

namespace Echange_Livres.Controllers
{
    public class CategorieController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Categorie
        public ActionResult Index()
        {
            return View(db.CategorieDTOes.ToList());
        }

        // GET: Categorie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategorieDTO categorieDTO = db.CategorieDTOes.Find(id);
            if (categorieDTO == null)
            {
                return HttpNotFound();
            }
            return View(categorieDTO);
        }

        // GET: Categorie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorie/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] CategorieDTO categorieDTO)
        {
            if (ModelState.IsValid)
            {
                db.CategorieDTOes.Add(categorieDTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorieDTO);
        }

        // GET: Categorie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategorieDTO categorieDTO = db.CategorieDTOes.Find(id);
            if (categorieDTO == null)
            {
                return HttpNotFound();
            }
            return View(categorieDTO);
        }

        // POST: Categorie/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] CategorieDTO categorieDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorieDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorieDTO);
        }

        // GET: Categorie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategorieDTO categorieDTO = db.CategorieDTOes.Find(id);
            if (categorieDTO == null)
            {
                return HttpNotFound();
            }
            return View(categorieDTO);
        }

        // POST: Categorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategorieDTO categorieDTO = db.CategorieDTOes.Find(id);
            db.CategorieDTOes.Remove(categorieDTO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
