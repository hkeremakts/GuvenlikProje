using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("Firmalar")]
    public class Firma:IEntity
    {
        public int Id { get; set; }
        public string FirmaAdi { get; set; }
        public string FirmaTelefonu { get; set; }
        public int FirmaYetkiliId { get; set; }
        public FirmaYetkili? FirmaYetkili { get; set; }
        public int AdresId { get; set; }
        public Adres? Adres { get; set; }
        public string TepeMusteriNo { get; set; }
        public int SatisKaynagiId { get; set; }
        public SatisKaynagi? SatisKaynagi { get; set; }
        public int SatisTemsilcisiId { get; set; }
        public SatisTemsilcisi? SatisTemsilcisi { get; set; }
        public int DurumId { get; set; }
        public Durum? Durum { get; set; }
        public int FarkliFirmaId { get; set; }
        public FarkliFirma? FarkliFirma { get; set; }
        public string Aciklama { get; set; }
        public string COGorusmeDetayi { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime OstimGorusmeTarihi { get; set; }
        public string OstimNot { get; set; }
        public string FirmaninAlarmIstemedigineDairYazi { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime TepeGorusmeTarihi { get; set; }
        public string TepeNot { get; set; }
        public int PaketTeslimIadeDurumuId { get; set; }
        public PaketTeslimIadeDurumu? PaketTeslimIadeDurumu { get; set; }
        public string MalzemeTeslimNo { get; set; }
        public bool MalzemeTeslimDurumu { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime MalzemeTeslimTarihi { get; set; }
        public bool KurulumDurumu { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime MontajTarihi { get; set; }
        public string SahaRevizeNot { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime SahaRevizeTarihi { get; set; }
    }
}
