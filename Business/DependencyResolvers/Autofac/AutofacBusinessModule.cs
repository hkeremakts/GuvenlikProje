using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstact;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FirmaManager>().As<IFirmaService>();
            builder.RegisterType<EfFirmaDal>().As<IFirmaDal>();

            builder.RegisterType<FirmaYetkiliManager>().As<IFirmaYetkiliService>();
            builder.RegisterType<EfFirmaYetkiliDal>().As<IFirmaYetkiliDal>();

            builder.RegisterType<AdresManager>().As<IAdresService>();
            builder.RegisterType<EfAdresDal>().As<IAdresDal>();

            builder.RegisterType<CaddeManager>().As<ICaddeService>();
            builder.RegisterType<EfCaddeDal>().As<ICaddeDal>();

            builder.RegisterType<DurumManager>().As<IDurumService>();
            builder.RegisterType<EfDurumDal>().As<IDurumDal>();

            builder.RegisterType<FarkliFirmaManager>().As<IFarkliFirmaService>();
            builder.RegisterType<EfFarkliFirmaDal>().As<IFarkliFirmaDal>();

            builder.RegisterType<PaketTeslimIadeDurumuManager>().As<IPaketTeslimIadeDurumuService>();
            builder.RegisterType<EfPaketTeslimIadeDurumuDal>().As<IPaketTeslimIadeDurumuDal>();

            builder.RegisterType<SatisKaynagiManager>().As<ISatisKaynagiService>();
            builder.RegisterType<EfSatisKaynagiDal>().As<ISatisKaynagiDal>();

            builder.RegisterType<SatisTemsilcisiManager>().As<ISatisTemsilcisiService>();
            builder.RegisterType<EfSatisTemsilcisiDal>().As<ISatisTemsilcisiDal>();

            builder.RegisterType<SokakManager>().As<ISokakService>();
            builder.RegisterType<EfSokakDal>().As<ISokakDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
