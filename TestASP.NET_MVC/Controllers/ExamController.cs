using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestASP.NET_MVC.Context;
using TestMVC.Models;

namespace TestASP.NET_MVC.Controllers
{
    public class ExamController : Controller
    {
        ExamContext db = new ExamContext();
        // GET: Exam
        public ActionResult Index()
        {
            return View(db.Exams.ToList());
        }

        // GET: Exam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Exam exam = db.Exams.Find(id);
            if (exam == null)
                return HttpNotFound();
            return View(exam);
        }

        // GET: Exam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exam/Create
        [HttpPost]
        public ActionResult Create(Exam exam)
        {
            try
            {
                db.Exams.Add(exam);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(exam);
            }
        }

        // GET: Exam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Exam exam = db.Exams.Find(id);
            if (exam == null)
                return HttpNotFound();
            return View(exam);
        }

        // POST: Exam/Edit/5
        [HttpPost]
        public ActionResult Edit(Exam exam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(exam).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(exam);
            }
            catch
            {
                return View();
            }
        }

        // GET: Exam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Exam exam = db.Exams.Find(id);
            if (exam == null)
                return HttpNotFound();
            return View(exam);
        }

        // POST: Exam/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Exam ex)
        {
            try
            {
                Exam exam = new Exam();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    exam = db.Exams.Find(id);
                    if (exam == null)
                        return HttpNotFound();
                    db.Exams.Remove(exam);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(exam);
            }
            catch
            {
                return View();
            }
        }
    }
}
