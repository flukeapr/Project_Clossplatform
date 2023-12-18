using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project13.Models;

namespace Project13
{
    public class BooksController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: Books/Details/5
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

        // GET: Books/Create
        public ActionResult Create()
        {

            var customCategories = new List<String>
        {
            "นิยาย" ,
            "อนิเมะ" ,
            "การ์ตูน" 
            // Add more categories as needed
        };

            // Set categories in ViewBag or ViewModel
            ViewBag.Categories = customCategories;

            // Create a new Book with Categories property
            var book = new Book
            {
                Categories = customCategories
            };

            return View(book);

        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Book_Id,Book_Name,Short_Story,Author,Publisher,Price,ImageUrl,SelectedCategoryText")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Category = book.SelectedCategoryText.ToString();
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Book_Image"), fileName);
                    file.SaveAs(path);
                    book.Image = fileName;
                }
                
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var customCategories = new List<String>
        {
            "นิยาย" ,
            "อนิเมะ" ,
            "การ์ตูน" 
            // Add more categories as needed
        };

            book.Categories = customCategories;
            ViewBag.Categories = customCategories;

            return View(book);


        }
       

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Book_Id,Book_Name,Category,Short_Story,Author,Publisher,Price,Image")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
