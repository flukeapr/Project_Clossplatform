using Project13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project13.Controllers
{
    public class HomeController : Controller
    {
        private Entities2 db = new Entities2();
        public ViewResult Index(string Searchstring)
        {
            var book = from p in db.Books
                       select p;
            if (!String.IsNullOrEmpty(Searchstring))
            {
                book = book.Where(p => p.Book_Name.Contains(Searchstring));
            }

            return View(book);
        }
        




        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}