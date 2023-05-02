using Business.Abstact;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Reflection;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Random rnd = new Random();
        Assembly entityAssembly = Assembly.GetAssembly(typeof(Firma));
        Assembly dalAssembly = Assembly.GetAssembly(typeof(EfFirmaDal));
        Assembly managerAssembly = Assembly.GetAssembly(typeof(FirmaManager));

        var entityTypes = entityAssembly.GetTypes().Where(e => e.GetInterface("IEntity") != null).ToList();
        var f = entityTypes.Where(e => e.Name == "Firma").SingleOrDefault();
        entityTypes.Remove(f);
        entityTypes.Add(f);
        var dalTypes = dalAssembly.GetTypes().Where(d => d.Name.Contains("Dal") == true
            && d.Name.Contains("User") == false);
        var managerTypes = managerAssembly.GetTypes().Where(m => m.Name.Contains("User") == false
            && m.Name.Contains("Auth") == false);

        foreach (var entityType in entityTypes)
        {
            var obj = Activator.CreateInstance(entityType);
            var properties = entityType.GetProperties();
            var dalType = dalTypes.Where(d => d.Name=="Ef"+entityType.Name+"Dal").FirstOrDefault();
            var managerType = managerTypes.Where(m => m.Name == entityType.Name + "Manager").FirstOrDefault();
            var dal = Activator.CreateInstance(dalType);
            var manager = Activator.CreateInstance(managerType, new Object[]
            {
                    dal
            });
            var managerAdd = managerType.GetMethod("Add");
            for (int i = 0; i < 15; i++)
            {
                foreach (var property in properties)
                {
                    if (property.Name.Contains("Id"))
                    {
                        if (property.Name != "Id")
                        {
                            property.SetValue(obj, rnd.Next(1, 15));
                        }
                    }
                    else
                    {
                        if (property.PropertyType == typeof(int))
                        {
                            property.SetValue(obj, rnd.Next(5, 100000));
                        }
                        else if (property.PropertyType == typeof(string))
                        {
                            property.SetValue(obj, CreateString(rnd, 3, 10));
                        }
                        else if (property.PropertyType == typeof(DateTime))
                        {
                            var dateTime = DateTime.Now.AddDays(rnd.Next(-10, 10));
                            property.SetValue(obj, dateTime);
                        }
                        else if (property.PropertyType == typeof(bool))
                        {
                            var b = rnd.Next(0, 2);
                            if (b == 0)
                            {
                                property.SetValue(obj, false);
                            }
                            else
                            {
                                property.SetValue(obj, true);
                            }
                        }
                        else
                        {
                            property.SetValue(obj, null);
                        }
                    }
                }
                managerAdd.Invoke(manager, new Object[]
                {
                    obj
                });
            }
        }



        //Random random = new Random();
        //List<Adres> adresList = new List<Adres>();
        //List<Firma> firmaList = new List<Firma>();
        //List<FirmaYetkili> firmaYetkiliList = new List<FirmaYetkili>();
        //List<Cadde> caddeList = new List<Cadde>();
        //List<Sokak> sokakList = new List<Sokak>();
        //List<Durum> durumList = new List<Durum>();
        //List<FarkliFirma> farkliFirmaList = new List<FarkliFirma>();
        //List<PaketTeslimIadeDurumu> paketTeslimIadeDurumuList = new List<PaketTeslimIadeDurumu>();
        //List<SatisKaynagi> satisKaynagiList = new List<SatisKaynagi>();
        //List<SatisTemsilcisi> satisTemsilcisiList = new List<SatisTemsilcisi>();

        //for (int i = 0; i < 10; i++)
        //{

        //}
        //Adres adres1 = new Adres()
        //{
        //    Id = 1,
        //    Ada = 12,
        //    AdresNo = "12321",
        //    CaddeId = 1,
        //    DisKapiNo = 13,
        //    IcKapiNo = 14,
        //    Parsel = 12,
        //    SokakId = 1
        //};
        //Adres adres2 = new Adres()
        //{
        //    Id = 1,
        //    Ada = 12,
        //    AdresNo = "12325",
        //    CaddeId = 1,
        //    DisKapiNo = 13,
        //    IcKapiNo = 15,
        //    Parsel = 12,
        //    SokakId = 1
        //};
        //Adres adres3 = new Adres()
        //{
        //    Id = 3,
        //    Ada = 12,
        //    AdresNo = "12324",
        //    CaddeId = 1,
        //    DisKapiNo = 13,
        //    IcKapiNo = 16,
        //    Parsel = 12,
        //    SokakId = 1
        //};
        //Adres adres4 = new Adres()
        //{
        //    Id = 4,
        //    Ada = 121,
        //    AdresNo = "12323",
        //    CaddeId = 1,
        //    DisKapiNo = 9,
        //    IcKapiNo = 11,
        //    Parsel = 14,
        //    SokakId = 1
        //};
        //Adres adres5 = new Adres()
        //{
        //    Id = 5,
        //    Ada = 1,
        //    AdresNo = "12322",
        //    CaddeId = 1,
        //    DisKapiNo = 10,
        //    IcKapiNo = 15,
        //    Parsel = 13,
        //    SokakId = 1
        //};
        //Adres adres6 = new Adres()
        //{
        //    Id = 6,
        //    Ada = 2,
        //    AdresNo = "54321",
        //    CaddeId = 1,
        //    DisKapiNo = 123,
        //    IcKapiNo = 145,
        //    Parsel = 121,
        //    SokakId = 1
        //};
        //Cadde cadde = new Cadde()
        //{
        //    Id = 1,
        //    CaddeAdi = "Cadde"
        //};
        //Durum durum = new Durum()
        //{
        //    Id = 1,
        //    DurumAdi = "Aktif"
        //};
        //FarkliFirma farkliFirma = new FarkliFirma()
        //{
        //    Id = 1,
        //    FarkliFirmaAdi = "Yok"
        //};

        //FirmaYetkili firmaYetkili = new FirmaYetkili()
        //{
        //    Id = 1,
        //    Adi = "Kerem Aktaş",
        //    TelefonNo = "05345831907"
        //};
        //PaketTeslimIadeDurumu paketTeslimIadeDurumu = new PaketTeslimIadeDurumu()
        //{
        //    Id = 1,
        //    PaketTeslimIadeDurumuAdi = "Teslim Edildi"
        //};
        //SatisKaynagi satisKaynagi = new SatisKaynagi()
        //{
        //    Id = 1,
        //    SatisKaynagiAdi = "Tepe"
        //};
        //SatisTemsilcisi satisTemsilcisi = new SatisTemsilcisi()
        //{
        //    Id = 1,
        //    SatisTemsilcisiAdi = "Kenan Aktaş"
        //};
        //Sokak sokak = new Sokak()
        //{
        //    Id = 1,
        //    SokakAdi = "Sokak"
        //};
        //Firma firma1 = new Firma()
        //{
        //    Id = 1,
        //    Aciklama = "yok",
        //    AdresId = 1,
        //    COGorusmeDetayi = "yok",
        //    DurumId = 1,
        //    FarkliFirmaId = 1,
        //    FirmaAdi = "Selin AŞ",
        //    FirmaTelefonu = "05345831907",
        //    FirmaYetkiliId = 1,
        //    KurulumDurumu = true,
        //    MalzemeTeslimDurumu = true,
        //    MalzemeTeslimNo = "32423",
        //    MalzemeTeslimTarihi = DateTime.Now,
        //    MontajTarihi = DateTime.Now.AddDays(2),
        //    OstimGorusmeTarihi = DateTime.Now.AddDays(-2),
        //    PaketTeslimIadeDurumuId = 1,
        //    SahaRevizeNot = "qwdas",
        //    SahaRevizeTarihi = DateTime.Now.AddDays(-5),
        //    SatisKaynagiId = 1,
        //    SatisTemsilcisiId = 1,
        //    TepeGorusmeTarihi = DateTime.Now.AddMonths(-1),
        //    TepeMusteriNo = "213123",
        //};
        //Firma firma2 = new Firma()
        //{
        //    Id = 2,
        //    Aciklama = "yok",
        //    AdresId = 2,
        //    COGorusmeDetayi = "yok",
        //    DurumId = 1,
        //    FarkliFirmaId = 1,
        //    FirmaAdi = "Selim AŞ",
        //    FirmaTelefonu = "05345831907",
        //    FirmaYetkiliId = 1,
        //    KurulumDurumu = true,
        //    MalzemeTeslimDurumu = true,
        //    MalzemeTeslimNo = "32423",
        //    MalzemeTeslimTarihi = DateTime.Now,
        //    MontajTarihi = DateTime.Now.AddDays(2),
        //    OstimGorusmeTarihi = DateTime.Now.AddDays(-2),
        //    PaketTeslimIadeDurumuId = 1,
        //    SahaRevizeNot = "qwdas",
        //    SahaRevizeTarihi = DateTime.Now.AddDays(-5),
        //    SatisKaynagiId = 1,
        //    SatisTemsilcisiId = 1,
        //    TepeGorusmeTarihi = DateTime.Now.AddMonths(-1),
        //    TepeMusteriNo = "213123",
        //};
        //Firma firma3 = new Firma()
        //{
        //    Id = 3,
        //    Aciklama = "yok",
        //    AdresId = 3,
        //    COGorusmeDetayi = "yok",
        //    DurumId = 1,
        //    FarkliFirmaId = 1,
        //    FirmaAdi = "Sel Taşıma AŞ",
        //    FirmaTelefonu = "05345831907",
        //    FirmaYetkiliId = 1,
        //    KurulumDurumu = true,
        //    MalzemeTeslimDurumu = true,
        //    MalzemeTeslimNo = "32423",
        //    MalzemeTeslimTarihi = DateTime.Now,
        //    MontajTarihi = DateTime.Now.AddDays(2),
        //    OstimGorusmeTarihi = DateTime.Now.AddDays(-2),
        //    PaketTeslimIadeDurumuId = 1,
        //    SahaRevizeNot = "qwdas",
        //    SahaRevizeTarihi = DateTime.Now.AddDays(-5),
        //    SatisKaynagiId = 1,
        //    SatisTemsilcisiId = 1,
        //    TepeGorusmeTarihi = DateTime.Now.AddMonths(-1),
        //    TepeMusteriNo = "213123",
        //};
        //Firma firma4 = new Firma()
        //{
        //    Id = 4,
        //    Aciklama = "yok",
        //    AdresId = 4,
        //    COGorusmeDetayi = "yok",
        //    DurumId = 1,
        //    FarkliFirmaId = 1,
        //    FirmaAdi = "Kerem AŞ",
        //    FirmaTelefonu = "05345831907",
        //    FirmaYetkiliId = 1,
        //    KurulumDurumu = true,
        //    MalzemeTeslimDurumu = true,
        //    MalzemeTeslimNo = "32423",
        //    MalzemeTeslimTarihi = DateTime.Now,
        //    MontajTarihi = DateTime.Now.AddDays(2),
        //    OstimGorusmeTarihi = DateTime.Now.AddDays(-2),
        //    PaketTeslimIadeDurumuId = 1,
        //    SahaRevizeNot = "qwdas",
        //    SahaRevizeTarihi = DateTime.Now.AddDays(-5),
        //    SatisKaynagiId = 1,
        //    SatisTemsilcisiId = 1,
        //    TepeGorusmeTarihi = DateTime.Now.AddMonths(-1),
        //    TepeMusteriNo = "213123",
        //};
        //Firma firma5 = new Firma()
        //{
        //    Id = 5,
        //    Aciklama = "yok",
        //    AdresId = 5,
        //    COGorusmeDetayi = "yok",
        //    DurumId = 1,
        //    FarkliFirmaId = 1,
        //    FirmaAdi = "Mustafa AŞ",
        //    FirmaTelefonu = "05345831907",
        //    FirmaYetkiliId = 1,
        //    KurulumDurumu = true,
        //    MalzemeTeslimDurumu = true,
        //    MalzemeTeslimNo = "32423",
        //    MalzemeTeslimTarihi = DateTime.Now,
        //    MontajTarihi = DateTime.Now.AddDays(2),
        //    OstimGorusmeTarihi = DateTime.Now.AddDays(-2),
        //    PaketTeslimIadeDurumuId = 1,
        //    SahaRevizeNot = "qwdas",
        //    SahaRevizeTarihi = DateTime.Now.AddDays(-5),
        //    SatisKaynagiId = 1,
        //    SatisTemsilcisiId = 1,
        //    TepeGorusmeTarihi = DateTime.Now.AddMonths(-1),
        //    TepeMusteriNo = "213123",
        //};
        //Firma firma6 = new Firma()
        //{
        //    Id = 6,
        //    Aciklama = "yok",
        //    AdresId = 6,
        //    COGorusmeDetayi = "yok",
        //    DurumId = 1,
        //    FarkliFirmaId = 1,
        //    FirmaAdi = "AklıSelim AŞ",
        //    FirmaTelefonu = "05345831907",
        //    FirmaYetkiliId = 1,
        //    KurulumDurumu = true,
        //    MalzemeTeslimDurumu = true,
        //    MalzemeTeslimNo = "32423",
        //    MalzemeTeslimTarihi = DateTime.Now,
        //    MontajTarihi = DateTime.Now.AddDays(2),
        //    OstimGorusmeTarihi = DateTime.Now.AddDays(-2),
        //    PaketTeslimIadeDurumuId = 1,
        //    SahaRevizeNot = "qwdas",
        //    SahaRevizeTarihi = DateTime.Now.AddDays(-5),
        //    SatisKaynagiId = 1,
        //    SatisTemsilcisiId = 1,
        //    TepeGorusmeTarihi = DateTime.Now.AddMonths(-1),
        //    TepeMusteriNo = "213123",
        //};
        //IAdresService adresService = InstanceFactory.GetInstance<IAdresService>();
        //ICaddeService caddeService = InstanceFactory.GetInstance<ICaddeService>();
        //IDurumService durumService = InstanceFactory.GetInstance<IDurumService>();
        //IFarkliFirmaService farkliFirmaService = InstanceFactory.GetInstance<IFarkliFirmaService>();
        //IFirmaService firmaService = InstanceFactory.GetInstance<IFirmaService>();
        //IFirmaYetkiliService firmaYetkiliService = InstanceFactory.GetInstance<IFirmaYetkiliService>();
        //IPaketTeslimIadeDurumuService paketTeslimIadeDurumuService = InstanceFactory.GetInstance<IPaketTeslimIadeDurumuService>();
        //ISatisKaynagiService satisKaynagiService = InstanceFactory.GetInstance<ISatisKaynagiService>();
        //ISatisTemsilcisiService satisTemsilcisiService = InstanceFactory.GetInstance<ISatisTemsilcisiService>();
        //ISokakService sokakService = InstanceFactory.GetInstance<ISokakService>();
        //caddeService.Add(cadde);
        //durumService.Add(durum);
        //farkliFirmaService.Add(farkliFirma);
        //firmaYetkiliService.Add(firmaYetkili);
        //paketTeslimIadeDurumuService.Add(paketTeslimIadeDurumu);
        //satisKaynagiService.Add(satisKaynagi);
        //satisTemsilcisiService.Add(satisTemsilcisi);
        //sokakService.Add(sokak);
        //adresService.Add(adres1);
        //adresService.Add(adres2);
        //adresService.Add(adres3);
        //adresService.Add(adres4);
        //adresService.Add(adres5);
        //adresService.Add(adres6);
        //firmaService.Add(firma1);
        //firmaService.Add(firma2);
        //firmaService.Add(firma3);
        //firmaService.Add(firma4);
        //firmaService.Add(firma5);
        //firmaService.Add(firma6);
    }
    public static string CreateString(Random random, int minValue = 0, int maxValue = int.MaxValue)
    {
        string str;
        byte[] bytes = new byte[random.Next(minValue, maxValue)];
        for (int j = 0; j < bytes.Length; j++)
        {
            bytes[j] = (byte)random.Next(97, 122);
        }
        str = Encoding.ASCII.GetString(bytes);
        return str;
    }
}