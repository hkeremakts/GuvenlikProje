using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFirmaDal : EfEntityRepositoryBase<Firma, GuvenlikProjeContext>, IFirmaDal
    {
        public List<FirmaComponentsDTO> GetAllFirmaComponentsDTOs(Expression<Func<FirmaComponentsDTO, bool>> filter = null)
        {
            using (GuvenlikProjeContext context = new GuvenlikProjeContext())
            {
                var result =
                    from firma in context.Firmas
                    join adres in context.Adress
                    on firma.Id equals adres.Id
                    join cadde in context.Caddes
                    on adres.CaddeId equals cadde.Id
                    join sokak in context.Sokaks
                    on adres.SokakId equals sokak.Id
                    join durum in context.Durums
                    on firma.DurumId equals durum.Id
                    join farkliFirma in context.FarkliFirmas
                    on firma.FarkliFirmaId equals farkliFirma.Id
                    join firmaYetkili in context.FirmaYetkilis
                    on firma.Id equals firmaYetkili.Id
                    join paketTeslimIadeDurumu in context.PaketTeslimIadeDurumus
                    on firma.PaketTeslimIadeDurumuId equals paketTeslimIadeDurumu.Id
                    join satisKaynagi in context.SatisKaynagis
                    on firma.SatisKaynagiId equals satisKaynagi.Id
                    join satisTemsilcisi in context.SatisTemsilcisis
                    on firma.SatisTemsilcisiId equals satisTemsilcisi.Id
                    select new FirmaComponentsDTO()
                    {
                        FirmaId=firma.Id,
                        Aciklama = firma.Aciklama,
                        Ada = adres.Ada,
                        AdresNo = adres.AdresNo,
                        COGorusmeDetayi = firma.COGorusmeDetayi,
                        CaddeAdi = cadde.CaddeAdi,
                        DisKapiNo = adres.DisKapiNo,
                        DurumAdi = durum.DurumAdi,
                        FarkliFirmaAdi = farkliFirma.FarkliFirmaAdi,
                        FirmaAdi = firma.FirmaAdi,
                        FirmaninAlarmIstemedigineDairYazi = firma.FirmaninAlarmIstemedigineDairYazi,
                        FirmaTelefonu = firma.FirmaTelefonu,
                        FirmaYetkiliAdi = firmaYetkili.Adi,
                        FirmaYetkiliTelefonNo = firmaYetkili.TelefonNo,
                        IcKapiNo = adres.IcKapiNo,
                        KurulumDurumu = firma.KurulumDurumu,
                        MalzemeTeslimDurumu = firma.MalzemeTeslimDurumu,
                        MalzemeTeslimNo = firma.MalzemeTeslimNo,
                        MalzemeTeslimTarihi = firma.MalzemeTeslimTarihi,
                        MontajTarihi = firma.MontajTarihi,
                        OstimGorusmeTarihi = firma.OstimGorusmeTarihi,
                        OstimNot = firma.OstimNot,
                        PaketTeslimIadeDurumuAdi = paketTeslimIadeDurumu.PaketTeslimIadeDurumuAdi,
                        Parsel = adres.Parsel,
                        SahaRevizeNot = firma.SahaRevizeNot,
                        SahaRevizeTarihi = firma.SahaRevizeTarihi,
                        SatisKaynagiAdi = satisKaynagi.SatisKaynagiAdi,
                        SatisTemsilcisiAdi = satisTemsilcisi.SatisTemsilcisiAdi,
                        SokakAdi = sokak.SokakAdi,
                        TepeGorusmeTarihi = firma.TepeGorusmeTarihi,
                        TepeMusteriNo = firma.TepeMusteriNo,
                        TepeNot = firma.TepeNot
                    };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

        public FirmaComponentsDTO GetFirmaComponentsDTO(Expression<Func<FirmaComponentsDTO, bool>> filter)
        {
            using (GuvenlikProjeContext context = new GuvenlikProjeContext())
            {
                var result =
                     from firma in context.Firmas
                     join adres in context.Adress
                     on firma.Id equals adres.Id
                     join cadde in context.Caddes
                     on adres.CaddeId equals cadde.Id
                     join sokak in context.Sokaks
                     on adres.SokakId equals sokak.Id
                     join durum in context.Durums
                     on firma.DurumId equals durum.Id
                     join farkliFirma in context.FarkliFirmas
                     on firma.FarkliFirmaId equals farkliFirma.Id
                     join firmaYetkili in context.FirmaYetkilis
                     on firma.Id equals firmaYetkili.Id
                     join paketTeslimIadeDurumu in context.PaketTeslimIadeDurumus
                     on firma.PaketTeslimIadeDurumuId equals paketTeslimIadeDurumu.Id
                     join satisKaynagi in context.SatisKaynagis
                     on firma.SatisKaynagiId equals satisKaynagi.Id
                     join satisTemsilcisi in context.SatisTemsilcisis
                     on firma.SatisTemsilcisiId equals satisTemsilcisi.Id
                     select new FirmaComponentsDTO()
                     {
                         FirmaId=firma.Id,
                         Aciklama = firma.Aciklama,
                         Ada = adres.Ada,
                         AdresNo = adres.AdresNo,
                         COGorusmeDetayi = firma.COGorusmeDetayi,
                         CaddeAdi = cadde.CaddeAdi,
                         DisKapiNo = adres.DisKapiNo,
                         DurumAdi = durum.DurumAdi,
                         FarkliFirmaAdi = farkliFirma.FarkliFirmaAdi,
                         FirmaAdi = firma.FirmaAdi,
                         FirmaninAlarmIstemedigineDairYazi = firma.FirmaninAlarmIstemedigineDairYazi,
                         FirmaTelefonu = firma.FirmaTelefonu,
                         FirmaYetkiliAdi = firmaYetkili.Adi,
                         FirmaYetkiliTelefonNo = firmaYetkili.TelefonNo,
                         IcKapiNo = adres.IcKapiNo,
                         KurulumDurumu = firma.KurulumDurumu,
                         MalzemeTeslimDurumu = firma.MalzemeTeslimDurumu,
                         MalzemeTeslimNo = firma.MalzemeTeslimNo,
                         MalzemeTeslimTarihi = firma.MalzemeTeslimTarihi,
                         MontajTarihi = firma.MontajTarihi,
                         OstimGorusmeTarihi = firma.OstimGorusmeTarihi,
                         OstimNot = firma.OstimNot,
                         PaketTeslimIadeDurumuAdi = paketTeslimIadeDurumu.PaketTeslimIadeDurumuAdi,
                         Parsel = adres.Parsel,
                         SahaRevizeNot = firma.SahaRevizeNot,
                         SahaRevizeTarihi = firma.SahaRevizeTarihi,
                         SatisKaynagiAdi = satisKaynagi.SatisKaynagiAdi,
                         SatisTemsilcisiAdi = satisTemsilcisi.SatisTemsilcisiAdi,
                         SokakAdi = sokak.SokakAdi,
                         TepeGorusmeTarihi = firma.TepeGorusmeTarihi,
                         TepeMusteriNo = firma.TepeMusteriNo,
                         TepeNot = firma.TepeNot
                     };
                return result.Where(filter).SingleOrDefault();

            }
        }
        public List<FirmaSearchDTO> GetFirmaSearchDTOs(string firmaAdi)
        {
            using (GuvenlikProjeContext context = new GuvenlikProjeContext())
            {
                var result = from adres in context.Adress
                             join firma in context.Firmas
                             on adres.Id equals firma.Id
                             where firma.FirmaAdi.Contains(firmaAdi)
                             select new FirmaSearchDTO()
                             {
                                 FirmaId=firma.Id,
                                 FirmaAdi = firma.FirmaAdi,
                                 FirmaTelefonu = firma.FirmaTelefonu,
                                 AdresNo = adres.AdresNo
                             };
                return result.ToList();
            }
        }

    }
}
