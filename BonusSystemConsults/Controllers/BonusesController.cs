using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BonusSystemConsults;
using BonusSystemConsults.Functions;
using BonusSystemConsults.Models;

namespace BonusSystemConsults.Controllers
{
    public class BonusesController : Controller
    {
        private ConsultBonusSystemDBEntities1 db = new ConsultBonusSystemDBEntities1();

        // GET: Bonuses
        public ActionResult Index()
        {
            List<Bonus> _bonus = db.Bonus.ToList();
            List<BonusViewModel> _bonuses = new List<BonusViewModel>();
            Consults consult = new Consults();

            foreach (var i in _bonus)
            {
                consult = db.Consults.Find(i.ConsultID);
                if (consult != null)
                {
                    _bonuses.Add(new BonusViewModel
                    {
                        BonusID = i.BonusID,
                        ConsultID = i.ConsultID,
                        Fullname = consult.FirstName + " " + consult.LastName,
                        NetResult = i.NetResult,
                        BonusPot = i.BonusPot,
                        TotalHoursWithBonus = i.TotalHoursWithBonus,
                        ChargedHoursWithBonus = i.ChargedHoursWithBonus,
                        ChargedHours = i.ChargedHours,
                        PeriodOfEmployment = i.PeriodOfEmployment,
                        BonusInMoney = i.BonusInMoney,
                        BonusDate = i.BonusDate
                    });

                }
                else
                {
                    _bonuses.Add(new BonusViewModel
                    {
                        BonusID = i.BonusID,
                        ConsultID = i.ConsultID,
                        Fullname = "Denna konsult är inte längre registrerad",
                        NetResult = i.NetResult,
                        BonusPot = i.BonusPot,
                        TotalHoursWithBonus = i.TotalHoursWithBonus,
                        ChargedHoursWithBonus = i.ChargedHoursWithBonus,
                        ChargedHours = i.ChargedHours,
                        PeriodOfEmployment = i.PeriodOfEmployment,
                        BonusInMoney = i.BonusInMoney,
                        BonusDate = i.BonusDate
                    });

                }


            }

            return View(_bonuses);
        }

        // GET: Bonuses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bonus = db.Bonus.Find(id);
            if (bonus == null)
            {
                return HttpNotFound();
            }

            return View(Functions.BonusFunctions.ConvertToModel(bonus));
        }
        [HttpGet]
        public PartialViewResult GetPostedBonus(int BonusID)
        {
            if (BonusID == 0)
            {
                return PartialView(Functions.BonusFunctions.GetBonusPostedDetails(0));
            }

            return PartialView(Functions.BonusFunctions.GetBonusPostedDetails(BonusID));
        }

        // GET: Bonuses/Create
        public ActionResult PostBonus()
        {
            var model = new PostBonus();
            model.GetPostedBonus = Functions.BonusFunctions.GetBonusPostedDetails(0);
            return View(model);
        }

        // POST: Bonuses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult PostBonus([Bind(Include = "ConsultID,NetResult,ChargedHours")] PostBonus postbonus)
        {
            var consult = db.Consults.Find(postbonus.ConsultID);
            if (consult == null)
            {
                postbonus.Message = "Detta anställningsnummer finns inte med i systemet.";
                postbonus.IsOK = false;
                return Json(postbonus, JsonRequestBehavior.DenyGet);
            }

            DateTime employmentDate = consult.EmploymentDate;
            int periodOfEmployment = BonusFunctions.GetEmpoymentTime(employmentDate);
            double chargedHoursWithBonus = BonusFunctions.GetLojalityFactor(periodOfEmployment, postbonus.ChargedHours);
            Bonus bonus = new Bonus();
            bonus.ConsultID = postbonus.ConsultID;
            bonus.NetResult = postbonus.NetResult;
            bonus.PeriodOfEmployment = periodOfEmployment;
            double bonuspot = postbonus.NetResult * 0.05;
            bonus.BonusPot = Convert.ToDecimal(bonuspot);
            bonus.ChargedHours = postbonus.ChargedHours;
            bonus.ChargedHoursWithBonus = Convert.ToInt32(chargedHoursWithBonus);
            bonus.BonusDate = DateTime.Now;
            var totalBonus = (from i in db.Bonus where i.BonusDate.Month == bonus.BonusDate.Month orderby i.BonusDate descending select i).ToList();
            totalBonus.Add(new Bonus { BonusID = 0, ConsultID = bonus.ConsultID, BonusDate = bonus.BonusDate, ChargedHoursWithBonus = bonus.ChargedHoursWithBonus });
            if( totalBonus.Count > 1)
            {
                foreach (var i in totalBonus)
                {
                    if (i.BonusDate.Month == bonus.BonusDate.Month)
                        bonus.TotalHoursWithBonus += i.ChargedHoursWithBonus;
                }
            }
            else
            {
                bonus.TotalHoursWithBonus = bonus.ChargedHoursWithBonus;
            }

            decimal partOfBonusHours = Convert.ToDecimal(chargedHoursWithBonus) / bonus.TotalHoursWithBonus;
            decimal bonusinmoney = bonus.BonusPot * partOfBonusHours;
            bonus.BonusInMoney = Math.Round(bonusinmoney);

            db.Bonus.Add(bonus);

            try
            {
                if (ModelState.IsValid)
                {
                    db.SaveChanges();
                    postbonus.BonusID = db.Bonus.Max(x => x.BonusID);
                    postbonus.Message = "Bonusen för denna konsult är nu skapad.";
                    postbonus.IsOK = true;
                    return Json(postbonus, JsonRequestBehavior.DenyGet);
                }

            }
            catch (DBConcurrencyException)
            {
                if (BonusExists(bonus.BonusID))
                {
                    postbonus.Message = "Denna konsult är redan registrerad.";
                    postbonus.IsOK = false;
                    return Json(postbonus, JsonRequestBehavior.DenyGet);
                }
                else
                {
                    throw;
                }
            }
            return Json(postbonus, JsonRequestBehavior.DenyGet);
        }

        // GET: Bonuses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bonus = db.Bonus.Find(id);
            if (bonus == null)
            {
                return HttpNotFound();
            }
            return View(bonus);
        }

        // POST: Bonuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var bonus = db.Bonus.Find(id);
            db.Bonus.Remove(bonus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool BonusExists(int id)
        {
            return db.Bonus.Any(e => e.BonusID == id);
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
