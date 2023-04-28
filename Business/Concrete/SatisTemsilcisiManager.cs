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
    public class SatisTemsilcisiManager : ISatisTemsilcisiService
    {
        ISatisTemsilcisiDal _satisTemsilcisiDal;
        public SatisTemsilcisiManager(ISatisTemsilcisiDal satisTemsilcisiDal)
        {
            _satisTemsilcisiDal=satisTemsilcisiDal;
        }
        public IResult Add(SatisTemsilcisi satisTemsilcisi)
        {
            _satisTemsilcisiDal.Add(satisTemsilcisi);
            return new SuccessResult();
        }

        public IResult Delete(SatisTemsilcisi satisTemsilcisi)
        {
            _satisTemsilcisiDal.Delete(satisTemsilcisi);
            return new SuccessResult();
        }

        public IDataResult<List<SatisTemsilcisi>> GetAll()
        {
            var result = _satisTemsilcisiDal.GetAll();
            return new SuccessDataResult<List<SatisTemsilcisi>>(result);
        }

        public IDataResult<SatisTemsilcisi> GetById(int id)
        {
            var result = _satisTemsilcisiDal.Get(s => s.Id == id);
            return new SuccessDataResult<SatisTemsilcisi>(result);
        }

        public IDataResult<SatisTemsilcisi> GetBySatisTemsilcisiAdi(string satisTemsilcisiAdi)
        {
            var result = _satisTemsilcisiDal.Get(s => s.SatisTemsilcisiAdi == satisTemsilcisiAdi);
            return new SuccessDataResult<SatisTemsilcisi>(result);
        }

        public IResult Update(SatisTemsilcisi satisTemsilcisi)
        {
            _satisTemsilcisiDal.Update(satisTemsilcisi);
            return new SuccessResult();
        }
    }
}
