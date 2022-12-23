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
    public class AbonnementController : Controller
    {
        // GET: Abonnement
        private AbonnementService AService = new AbonnementService(new AbonnementRepository(new MyContext()));
        private MyContext context = new MyContext();


        // GET: Abonnement
        public ActionResult Index()
        {
            List<Abonnement> lst = AService.GetAll();
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }



        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Abonnement abonnement)
        {
            if (ModelState.IsValid)
            {
                AService.Add(abonnement);
                return RedirectToAction("index");
            }
            return View(abonnement);
        }



        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonnement abonnement = context.Abonnements.Find(id);
            if (abonnement == null)
            {
                return HttpNotFound();
            }
            return View(abonnement);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Abonnement abonnement = context.Abonnements.Find(id);
            AService.Delete(abonnement);
            return RedirectToAction("Index");
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonnement abonnement = context.Abonnements.Find(id);
            if (abonnement == null)
            {
                return HttpNotFound();
            }
            return View(abonnement);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Abonnement abonnement)
        {
            if (ModelState.IsValid)
            {
                AService.Update(abonnement);
                return RedirectToAction("Index");
            }
            return View(abonnement);
        }
    }
}