using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CompanyNote.Models;

namespace CompanyNote.Controllers
{
    public class CompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Companies
        public ActionResult AllCompanies()
        {
            const int num = 0;
            ViewBag.Num = num;
            return View(db.Companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/GetCompanyById/5
        public ActionResult GetCompanyById(int? id)
        {
            Company comp = db.Companies.Find(id);
            Note note = new Note { CompanyId = comp };
            ViewBag.IDofCompany = comp.Id;
            ViewBag.NameofCompany = comp.CompanyName;
            return View ("~/Views/Notes/CreateByIdOfCompany.cshtml", note);
        }

       
       [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyName")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("AllCompanies");
            }

            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyName")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AllCompanies");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            List<Note> notesToDel = this.GetListOfNotesByCompany(company);
            db.Notes.RemoveRange(notesToDel);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("AllCompanies");
        }

        //вспомогательный метод для поиска взаимосвязанного с удаляемой компанией списка записей на прием
        public List<Note> GetListOfNotesByCompany(Company comp)
        {
            var temp1 = comp.GetHashCode();
            List<Note> notesListToDel = new List<Note>();
            var AllNotes = db.Notes
                            .Include(_ => _.CompanyId)
                            .ToList()
                            ;
            foreach (var t in AllNotes)
            {
                var temp2 = t.CompanyId.GetHashCode();
                if (temp1 == temp2)
                {
                    notesListToDel.Add(t);
                }
            }
            return notesListToDel;
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
