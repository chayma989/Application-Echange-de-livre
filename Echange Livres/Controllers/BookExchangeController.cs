using Echange_Livres.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Echange_Livres.Controllers
{
    public class BookExchangeController : Controller
    {
        private BookExchangeService bookEx = new BookExchangeService(new Repositories.BookExchangeRepository());
        // GET: BookExchange
        public ActionResult Index()
        {
            return View();
        }
    }
}