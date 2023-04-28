using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class FirmaComponentsDTO
    {
        public int FirmaId { get; set; }
        public string FirmaAdi { get; set; }
        public string FirmaTelefonu { get; set; }
        public string FirmaYetkiliAdi { get; set; }
        public string FirmaYetkiliTelefonNo { get; set; }
        public string AdresNo { get; set; }
        public string CaddeAdi { get; set; }
        public string SokakAdi { get; set; }
        public int DisKapiNo { get; set; }
        public int IcKapiNo { get; set; }
        public int Ada { get; set; }
        public int Parsel { get; set; }
        public string TepeMusteriNo { get; set; }
        public string SatisKaynagiAdi { get; set; }
        public string SatisTemsilcisiAdi { get; set; }
        public string DurumAdi { get; set; }
        public string FarkliFirmaAdi { get; set; }
        public string Aciklama { get; set; }
        public string COGorusmeDetayi { get; set; }
        public DateTime OstimGorusmeTarihi { get; set; }
        public string OstimNot { get; set; }
        public string FirmaninAlarmIstemedigineDairYazi { get; set; }
        public DateTime TepeGorusmeTarihi { get; set; }
        public string TepeNot { get; set; }
        public string PaketTeslimIadeDurumuAdi { get; set; }
        public string MalzemeTeslimNo { get; set; }
        public bool MalzemeTeslimDurumu { get; set; }
        public DateTime MalzemeTeslimTarihi { get; set; }
        public bool KurulumDurumu { get; set; }
        public DateTime MontajTarihi { get; set; }
        public string SahaRevizeNot { get; set; }
        public DateTime SahaRevizeTarihi { get; set; }
    }
}
