using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class GuvenlikProjeContext : DbContext
    {
        public GuvenlikProjeContext() : base("GuvenlikProjeDatabase")
        {
            //Database.SetInitializer<GuvenlikProjeContext>(new DropCreateDatabaseAlways<GuvenlikProjeContext>());
        }
        public DbSet<Firma> Firmas { get; set; }
        public DbSet<FirmaYetkili> FirmaYetkilis { get; set; }
        public DbSet<Adres> Adress { get; set; }
        public DbSet<Cadde> Caddes { get; set; }
        public DbSet<Durum> Durums { get; set; }
        public DbSet<FarkliFirma> FarkliFirmas { get; set; }
        public DbSet<PaketTeslimIadeDurumu> PaketTeslimIadeDurumus { get; set; }
        public DbSet<SatisKaynagi> SatisKaynagis { get; set; }
        public DbSet<SatisTemsilcisi> SatisTemsilcisis { get; set; }
        public DbSet<Sokak> Sokaks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
