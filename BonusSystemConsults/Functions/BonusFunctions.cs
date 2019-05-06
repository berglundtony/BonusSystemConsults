using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BonusSystemConsults.Models;
using NodaTime;

namespace BonusSystemConsults.Functions
{
    public static class BonusFunctions
    {
        private static string message = "";

        public static int GetEmpoymentTime(DateTime employmentDate)
        {
            var year = employmentDate.Year;
            var month = employmentDate.Month;
            var day = employmentDate.Day;

            DateTime currentDate = DateTime.Now;
            var yearToday = currentDate.Year;
            var monthToday = currentDate.Month;
            var dayToday = currentDate.Day;

            LocalDate start = new LocalDate(year, month, day);
            LocalDate now = new LocalDate(yearToday, monthToday, dayToday);
            Period period = Period.Between(start, now, PeriodUnits.Years | PeriodUnits.Months);

            return period.Years;
        }

        public static double GetLojalityFactor(int periodOfEmployment, int debitHours)
        {
            double lojalityFactor = 0.0;

            Dictionary<int, double> bonusYears = new Dictionary<int, double>();

            bonusYears.Add(0, 1);
            bonusYears.Add(1, 1.1);
            bonusYears.Add(2, 1.2);
            bonusYears.Add(3, 1.3);
            bonusYears.Add(4, 1.4);
            bonusYears.Add(5, 1.5);

            int years = periodOfEmployment;

            if (years == 0)
            {
                bonusYears.TryGetValue(0, out lojalityFactor);
                return lojalityFactor * debitHours;
            }
            else if (years == 1)
            {
                bonusYears.TryGetValue(1, out lojalityFactor);
                return lojalityFactor * debitHours;
            }
            else if (years == 2)
            {
                bonusYears.TryGetValue(2, out lojalityFactor);
                return lojalityFactor * debitHours;
            }
            else if (years == 3)
            {
                bonusYears.TryGetValue(3, out lojalityFactor);
                return lojalityFactor * debitHours;
            }
            else if (years == 4)
            {
                bonusYears.TryGetValue(4, out lojalityFactor);
                return lojalityFactor * debitHours;
            }
            else
            {
                bonusYears.TryGetValue(5, out lojalityFactor);
                return lojalityFactor * debitHours;
            }
        }
        public static Bonuses ConvertToModel(Bonus bonus)
        {
            Bonuses model = new Bonuses();
            model.BonusID = bonus.BonusID;
            model.ConsultID = bonus.ConsultID;
            model.NetResult = bonus.NetResult;
            model.BonusPot = bonus.BonusPot;
            model.TotalHoursWithBonus = bonus.TotalHoursWithBonus;
            model.ChargedHours = bonus.ChargedHours;
            model.ChargedHoursWithBonus = bonus.ChargedHoursWithBonus;
            model.PeriodOfEmployment = bonus.PeriodOfEmployment;
            model.BonusInMoney = bonus.BonusInMoney;
            model.BonusDate = bonus.BonusDate;

            return model;
        }

        public static BonusViewModel GetBonusPostedDetails(int bonusid)
        {
            var model = new BonusViewModel();

            if (bonusid == 0)
            {
                model.BonusID = bonusid;
                model.ConsultID = 0;
                model.Fullname = "";
                model.NetResult = 0;
                model.BonusPot = 0;
                model.TotalHoursWithBonus = 0;
                model.ChargedHours = 0;
                model.ChargedHoursWithBonus = 0;
                model.PeriodOfEmployment = 0;
                model.BonusInMoney = 0;
                model.BonusDate = DateTime.MinValue;
            }
            else
            {
                try
                {
                    using (var DB = new ConsultBonusSystemDBEntities1())
                    {
                        var result = DB.Bonus.Find(bonusid);
                        var consult = DB.Consults.Find(result.ConsultID);
                        model.BonusID = result.BonusID;
                        model.ConsultID = result.ConsultID;
                        model.Fullname = consult.FirstName + " " + consult.LastName;
                        model.NetResult = result.NetResult;
                        model.BonusPot = result.BonusPot;
                        model.TotalHoursWithBonus = result.TotalHoursWithBonus;
                        model.ChargedHours = result.ChargedHours;
                        model.ChargedHoursWithBonus = result.ChargedHoursWithBonus;
                        model.PeriodOfEmployment = result.PeriodOfEmployment;
                        model.BonusInMoney = result.BonusInMoney;
                        model.BonusDate = result.BonusDate;
                    };
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }

            return model;
        }
    }
}