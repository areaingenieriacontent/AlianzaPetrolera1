using AlianzaPetrolera.Models;
using AlianzaPetrolera.Models.Admin;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AlianzaPetrolera.Controllers.Admin
{
    public class RegistroCategoriaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Categoria
        public int CalcEdad(DateTime FechaNaci) {

            DateTime now = DateTime.Today;
            int edadest = DateTime.Today.Year - FechaNaci.Year;

            if (now < FechaNaci.AddYears(edadest))
            {
                edadest--;
                return edadest;
            }
            else
            {
                return edadest;
            }

        }
        public ActionResult Index(string nombreestudiante, int Insc_Id1, int documentoestu, string apellidoestu, string idestu, DateTime FechaNaci)
        {

            ViewBag.Message = nombreestudiante;
            ViewBag.IdInscripcion = Insc_Id1;
            ViewBag.documentoestud = documentoestu;
            ViewBag.apellidoes = apellidoestu;
            ViewBag.idest = idestu;
            ViewBag.FechaNaci = FechaNaci;
            ViewBag.Edad = CalcEdad(FechaNaci);

            var TodasCate = db.Categorias.ToList();
            return View(TodasCate);
        }

        public ActionResult ImprimirTodas()
        {
            var q = new ActionAsPdf("Index");
            return q;
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Categoria X = db.Categorias.Find(id);
                if (X == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(X);
                }
            }
        }


        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(Categoria Categorias)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    db.Categorias.Add(Categorias);
                    db.SaveChanges();

                    return RedirectToAction("Index","home");
                }
                return View(Categorias);
            }
            catch
            {
                return View(Categorias);
            }
        }



        //// GET: Categoria/Create
        //public ActionResult Matricular()
        //{
        //    return View();
        //}

        //// POST: Categoria/Create
        //[HttpPost]
        //public ActionResult Matricular(Matricula Matriculas, int Insc_Id1)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var Matricula = new Matricula { Insc_Id = Insc_Id1,};

        //    }

        //}




        // GET: RegistroPersona/Edit/5
        public ActionResult Edit(int? id)
        {
            var item = db.Categorias.Where(x => x.Cate_Id == id).First();
            return View(item);
        }

        // POST: RegistroPersona/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, FormCollection collection, Categoria model)
        {
            try
            {
                // TODO: Add update logic here
                var item = db.Categorias.Where(x => x.Cate_Id == model.Cate_Id).First();
                item.Cate_Id = model.Cate_Id;
                item.Cate_Name = model.Cate_Name;

                db.SaveChanges();
                return RedirectToAction("Index", "home");
            }
            catch
            {
                return RedirectToAction("Index", "home");
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Categoria X = db.Categorias.Find(id);
                if (X == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(X);
                }
            }

        }

        // POST: RegistroPersona/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection, Categoria X)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    X = db.Categorias.Find(id);

                    if (X == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        db.Categorias.Remove(X);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(X);
            }
            catch
            {
                return View(X);
            }
        }

    }



}