using System;
using System.ComponentModel.DataAnnotations;

namespace BonusSystemConsults.Models
{
    public class Consult
    {
        [Key]
        [Display(Name = "Anställningsnummer")]
        public int ConsultID { get; set; }
        [Required]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Anställningsdatum")]
        [DataType(DataType.Date)]
        public DateTime EmploymentDate { get; set; }
    }

    public class Bonuses
    {
        [Key]
        public int BonusID { get; set; }
        [Required]
        [Display(Name = "Anställningsnummer")]
        public int ConsultID { get; set; }
        [Required]
        [Display(Name = "Nettoresultat")]
        public decimal NetResult { get; set; }
        [Required]
        [Display(Name = "Bonuspott")]
        public decimal BonusPot { get; set; }
        [Display(Name = "Totala bonustimmar")]
        public int TotalHoursWithBonus { get; set; }
        [Required]
        [Display(Name = "Debiterade timmar")]
        public int ChargedHours { get; set; }
        [Required]
        [Display(Name = "Bonustimmar")]
        public int? ChargedHoursWithBonus { get; set; }
        [Required]
        [Display(Name = "Antällningstid i år")]
        public int? PeriodOfEmployment { get; set; }
        [Display(Name = "Bonus")]
        public decimal? BonusInMoney { get; set; }
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        public DateTime BonusDate { get; set; }
    }

    public class BonusViewModel
    {
        [Key]
        public int BonusID { get; set; }
        [Required]
        [Display(Name = "Anställningsnummer")]
        public int ConsultID { get; set; }
        [Required]
        [Display(Name = "Namn")]
        public string Fullname { get; set; }
        [Required]
        [Display(Name = "Nettoresultat")]
        public decimal NetResult { get; set; }
        [Required]
        [Display(Name = "Bonuspott")]
        public decimal BonusPot { get; set; }
        [Required]
        [Display(Name = "Totala bonustimmar")]
        public int TotalHoursWithBonus { get; set; }
        [Required]
        [Display(Name = "Debiterade timmar")]
        public int ChargedHours { get; set; }
        [Required]
        [Display(Name = "Bonustimmar")]
        public int ChargedHoursWithBonus { get; set; }
        [Required]
        [Display(Name = "Antällningstid i år")]
        public int? PeriodOfEmployment { get; set; }
        [Required]
        [Display(Name = "Bonus")]
        public decimal? BonusInMoney { get; set; }
        [Required]
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        public DateTime BonusDate { get; set; }
        public string Message { get; set; }
    }

    public class CreateBonus
    {
   
        public PostBonus InsertBonus { get; set; }
        public CreateBonus()
        {
            this.InsertBonus = new PostBonus();
          
        }
    }

    public class PostBonus
    {
        [Key]
        public int BonusID { get; set; }
        [Required(ErrorMessage = "Ange anställningsnummer")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Ange en korrekt siffra i heltal")]
        [Display(Name = "Anställningsnummer")]
        public int ConsultID { get; set; }
        [Required(ErrorMessage = "Ange debiterade timmar")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Ange en korrekt siffra i heltal")]
        [Display(Name = "Debiterade timmar")]
        public int ChargedHours { get; set; }
        [Required(ErrorMessage = "Ange nettoresultat")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Ange en korrekt siffra i heltal")]
        [Display(Name = "Nettoresultat")]
        public int NetResult { get; set; }
        public string Message { get; set; }
        public bool IsOK { get; set; }
        public BonusViewModel GetPostedBonus { get; set; }

        public PostBonus()
        {
            this.GetPostedBonus = new BonusViewModel();
        }
    }

}