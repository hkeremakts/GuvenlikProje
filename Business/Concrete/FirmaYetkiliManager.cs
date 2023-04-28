using Business.Abstact;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FirmaYetkiliManager : IFirmaYetkiliService
    {
        IFirmaYetkiliDal _firmaYetkiliDal;
        public FirmaYetkiliManager(IFirmaYetkiliDal firmaYetkiliDal)
        {
            _firmaYetkiliDal = firmaYetkiliDal;
        }
        public IResult Add(FirmaYetkili firmaYetkili)
        {
            _firmaYetkiliDal.Add(firmaYetkili);
            return new SuccessResult();
        }

        public IResult Delete(FirmaYetkili firmaYetkili)
        {
            _firmaYetkiliDal.Delete(firmaYetkili);
            return new SuccessResult();
        }

        public IDataResult<List<FirmaYetkili>> GetAll()
        {
            var result = _firmaYetkiliDal.GetAll();
            return new SuccessDataResult<List<FirmaYetkili>>(result);
        }

        public IDataResult<FirmaYetkili> GetByFirmaYetkiliAdi(string firmaYetkiliAdi)
        {
            var result = _firmaYetkiliDal.Get(f => f.Adi == firmaYetkiliAdi);
            return new SuccessDataResult<FirmaYetkili>(result);
        }

        public IDataResult<FirmaYetkili> GetById(int id)
        {
            var result = _firmaYetkiliDal.Get(f => f.Id == id);
            return new SuccessDataResult<FirmaYetkili>(result);
        }

        public IResult Update(FirmaYetkili firmaYetkili)
        {
            _firmaYetkiliDal.Update(firmaYetkili);
            return new SuccessResult();
        }
    }
}
