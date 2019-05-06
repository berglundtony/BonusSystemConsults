using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BonusSystemConsults;
using BonusSystemConsults.Models;

namespace BonusSystemConsults.Controllers
{
    public class ConsultsController : Controller
    {
        private ConsultBonusSystemDBEntities1 db = new ConsultBonusSystemDBEntities1();

        // GET: Consults
        public ActionResult Index()
        {
            List<Consults> _consults = db.Consults.ToList();
            List<Consult> _model = new List<Consult>();
            foreach (var i in _consults)
            {
                _model.Add(new Consult { ConsultID = i.ConsultID, FirstName = i.FirstName, LastName = i.LastName, EmploymentDate = i.EmploymentDate });
            }
            return View(_model.AsEnumerable());
        }

        // GET: Consults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consult consult = new Consult();
            var consultfind = db.Consults.Find(id);
            if (consultfind == null)
            {
                return HttpNotFound();
            }
            consult.ConsultID = consultfind.ConsultID;
            consult.FirstName = consultfind.FirstName;
            consult.LastName = consultfind.LastName;
            consult.EmploymentDate = consultfind.EmploymentDate;

            return View(consult);
        }

        // GET: Consults/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConsultID,FirstName,LastName,EmploymentDate")] Consults consult)
        {

            if (ModelState.IsValid)
            {
                db.Consults.Add(consult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consult);
        }

        // GET: Consults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consult consult = new Consult();
            var consultfind = db.Consults.Find(id);
            if (consultfind == null)
            {
                return HttpNotFound();
            }
            consult.ConsultID = consultfind.ConsultID;
            consult.FirstName = consultfind.FirstName;
            consult.LastName = consultfind.LastName;
            consult.EmploymentDate = consultfind.EmploymentDate;

            return View(consult);
        }

        // POST: Consults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsultID,FirstName,LastName,EmploymentDate")] Consults consult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consult);
        }

        // GET: Consults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consult consult = new Consult();
            var consultfind = db.Consults.Find(id);
            if (consultfind == null)
            {
                return HttpNotFound();
            }
            consult.ConsultID = consultfind.ConsultID;
            consult.FirstName = consultfind.FirstName;
            consult.LastName = consultfind.LastName;
            consult.EmploymentDate = consultfind.EmploymentDate;

            return View(consult);
        }

        // POST: Consults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var consult = db.Consults.Find(id);
            db.Consults.Remove(consult);
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
