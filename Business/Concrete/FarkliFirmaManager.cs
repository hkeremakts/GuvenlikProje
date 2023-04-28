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
    public class FarkliFirmaManager : IFarkliFirmaService
    {
        IFarkliFirmaDal _farkliFirmaDal;
        public FarkliFirmaManager(IFarkliFirmaDal farkliFirmaDal)
        {
            _farkliFirmaDal= farkliFirmaDal;
        }
        public IResult Add(FarkliFirma farkliFirma)
        {
            _farkliFirmaDal.Add(farkliFirma);
            return new SuccessResult();
        }

        public IResult Delete(FarkliFirma farkliFirma)
        {
            _farkliFirmaDal.Delete(farkliFirma);
            return new SuccessResult();
        }

        public IDataResult<List<FarkliFirma>> GetAll()
        {
            var result = _farkliFirmaDal.GetAll();
            return new SuccessDataResult<List<FarkliFirma>>(result);
        }

        public IDataResult<FarkliFirma> GetByFarkliFirmaAdi(string farkliFirmaAdi)
        {
            var result = _farkliFirmaDal.Get(f => f.FarkliFirmaAdi == farkliFirmaAdi);
            return new SuccessDataResult<FarkliFirma>(result);
        }

        public IDataResult<FarkliFirma> GetById(int id)
        {
            var result = _farkliFirmaDal.Get(f => f.Id == id);
            return new SuccessDataResult<FarkliFirma>(result);
        }

        public IResult Update(FarkliFirma farkliFirma)
        {
            _farkliFirmaDal.Update(farkliFirma);
            return new SuccessResult();
        }
    }
}
