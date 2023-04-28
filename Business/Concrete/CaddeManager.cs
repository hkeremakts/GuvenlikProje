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
    public class CaddeManager : ICaddeService
    {
        ICaddeDal _caddeDal;
        public CaddeManager(ICaddeDal caddeDal)
        {
            _caddeDal = caddeDal;
        }
        public IResult Add(Cadde cadde)
        {
            _caddeDal.Add(cadde);
            return new SuccessResult();
        }

        public IResult Delete(Cadde cadde)
        {
            _caddeDal.Delete(cadde);
            return new SuccessResult();
        }

        public IDataResult<List<Cadde>> GetAll()
        {
            var result = _caddeDal.GetAll();
            return new SuccessDataResult<List<Cadde>>(result);
        }

        public IDataResult<Cadde> GetByCaddeAdi(string caddeAdi)
        {
            var result = _caddeDal.Get(c => c.CaddeAdi == caddeAdi);
            return new SuccessDataResult<Cadde>(result);
        }

        public IDataResult<Cadde> GetById(int id)
        {
            var result = _caddeDal.Get(c => c.Id == id);
            return new SuccessDataResult<Cadde>(result);
        }

        public IResult Update(Cadde cadde)
        {
            _caddeDal.Update(cadde);
            return new SuccessResult();
        }
    }
}
