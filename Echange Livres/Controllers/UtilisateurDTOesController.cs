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
    public class UtilisateurDTOesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: UtilisateurDTOes
        public ActionResult Index()
        {
            return View(db.UtilisateurDTOes.ToList());
        }

        // GET: UtilisateurDTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilisateurDTO utilisateurDTO = db.UtilisateurDTOes.Find(id);
            if (utilisateurDTO == null)
            {
                return HttpNotFound();
            }
            return View(utilisateurDTO);
        }

        // GET: UtilisateurDTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UtilisateurDTOes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Password,Adresse,TotalPoints,Photo,IsAdmin")] UtilisateurDTO utilisateurDTO)
        {
            if (ModelState.IsValid)
            {
                db.UtilisateurDTOes.Add(utilisateurDTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utilisateurDTO);
        }

        // GET: UtilisateurDTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilisateurDTO utilisateurDTO = db.UtilisateurDTOes.Find(id);
            if (utilisateurDTO == null)
            {
                return HttpNotFound();
            }
            return View(utilisateurDTO);
        }

        // POST: UtilisateurDTOes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Password,Adresse,TotalPoints,Photo,IsAdmin")] UtilisateurDTO utilisateurDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilisateurDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utilisateurDTO);
        }

        // GET: UtilisateurDTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilisateurDTO utilisateurDTO = db.UtilisateurDTOes.Find(id);
            if (utilisateurDTO == null)
            {
                return HttpNotFound();
            }
            return View(utilisateurDTO);
        }

        // POST: UtilisateurDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UtilisateurDTO utilisateurDTO = db.UtilisateurDTOes.Find(id);
            db.UtilisateurDTOes.Remove(utilisateurDTO);
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
