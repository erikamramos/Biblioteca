using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class LibroesController : Controller
    {
        private BIBLIO_UCSMEntities db = new BIBLIO_UCSMEntities();

        // GET: Libroes
        public ActionResult Index()
        {
            return View(db.Libros.ToList());
        }

        // GET: Libroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Libroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,COD1,COD2,COD3,COD4,COD5,Titulo,Autor,Contenido,palabrasClave,Enlace,Pri_isbn,Pri_tifb,img,Tip_coleccion,Compl,Edicion,Lugar,Editorial,Anyo,Longitud,Paginas,Tipomater,URL,Idioma,IdEditorial,Anyo_reimp,Fecha,Estado_eliminacion,contenidoOK")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Libros.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(libro);
        }

        // GET: Libroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,COD1,COD2,COD3,COD4,COD5,Titulo,Autor,Contenido,palabrasClave,Enlace,Pri_isbn,Pri_tifb,img,Tip_coleccion,Compl,Edicion,Lugar,Editorial,Anyo,Longitud,Paginas,Tipomater,URL,Idioma,IdEditorial,Anyo_reimp,Fecha,Estado_eliminacion,contenidoOK")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(libro);
        }

        // GET: Libroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Libro libro = db.Libros.Find(id);
            db.Libros.Remove(libro);
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
