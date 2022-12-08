﻿using System;
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
    public class AbonnementController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Abonnement
        public ActionResult Index()
        {
            return View(db.AbonnementDTOes.ToList());
        }

        // GET: Abonnement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbonnementDTO abonnementDTO = db.AbonnementDTOes.Find(id);
            if (abonnementDTO == null)
            {
                return HttpNotFound();
            }
            return View(abonnementDTO);
        }

        // GET: Abonnement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Abonnement/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsAbo")] AbonnementDTO abonnementDTO)
        {
            if (ModelState.IsValid)
            {
                db.AbonnementDTOes.Add(abonnementDTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(abonnementDTO);
        }

        // GET: Abonnement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbonnementDTO abonnementDTO = db.AbonnementDTOes.Find(id);
            if (abonnementDTO == null)
            {
                return HttpNotFound();
            }
            return View(abonnementDTO);
        }

        // POST: Abonnement/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsAbo")] AbonnementDTO abonnementDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abonnementDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abonnementDTO);
        }

        // GET: Abonnement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbonnementDTO abonnementDTO = db.AbonnementDTOes.Find(id);
            if (abonnementDTO == null)
            {
                return HttpNotFound();
            }
            return View(abonnementDTO);
        }

        // POST: Abonnement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AbonnementDTO abonnementDTO = db.AbonnementDTOes.Find(id);
            db.AbonnementDTOes.Remove(abonnementDTO);
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
