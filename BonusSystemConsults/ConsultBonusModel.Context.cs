﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BonusSystemConsults
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ConsultBonusSystemDBEntities1 : DbContext
    {
        public ConsultBonusSystemDBEntities1()
            : base("name=ConsultBonusSystemDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bonus> Bonus { get; set; }
        public virtual DbSet<Consults> Consults { get; set; }
        public virtual DbSet<C__EFMigrationsHistory> C__EFMigrationsHistory { get; set; }
    }
}
