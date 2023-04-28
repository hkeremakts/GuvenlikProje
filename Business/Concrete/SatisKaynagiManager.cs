using Business.Abstact;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SatisKaynagiManager : ISatisKaynagiService
    {
        ISatisKaynagiDal _satisKaynagiDal;
        public SatisKaynagiManager(ISatisKaynagiDal satisKaynagiDal)
        {
            _satisKaynagiDal=satisKaynagiDal;
        }
        public IResult Add(SatisKaynagi satisKaynagi)
        {
            _satisKaynagiDal.Add(satisKaynagi);
            return new SuccessResult();
        }

        public IResult Delete(SatisKaynagi satisKaynagi)
        {
            _satisKaynagiDal.Delete(satisKaynagi);
            return new SuccessResult();
        }

        public IDataResult<List<SatisKaynagi>> GetAll()
        {
            var result = _satisKaynagiDal.GetAll();
            return new SuccessDataResult<List<SatisKaynagi>>(result);
        }

        public IDataResult<SatisKaynagi> GetById(int id)
        {
            var result = _satisKaynagiDal.Get(s => s.Id == id);
            return new SuccessDataResult<SatisKaynagi>(result);
        }

        public IDataResult<SatisKaynagi> GetBySatisKaynagiAdi(string satisKaynagiAdi)
        {
            var result = _satisKaynagiDal.Get(s => s.SatisKaynagiAdi == satisKaynagiAdi);
            return new SuccessDataResult<SatisKaynagi>(result);
        }

        public IResult Update(SatisKaynagi satisKaynagi)
        {
            _satisKaynagiDal.Update(satisKaynagi);
            return new SuccessResult();
        }
    }
}
