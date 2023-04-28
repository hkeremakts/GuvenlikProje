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
    public class DurumManager : IDurumService
    {
        IDurumDal _durumDal;
        public DurumManager(IDurumDal durumDal)
        {
            _durumDal = durumDal;
        }
        public IResult Add(Durum durum)
        {
            _durumDal.Add(durum);
            return new SuccessResult();
        }

        public IResult Delete(Durum durum)
        {
            _durumDal.Delete(durum);
            return new SuccessResult();
        }

        public IDataResult<List<Durum>> GetAll()
        {
            var result = _durumDal.GetAll();
            return new SuccessDataResult<List<Durum>>(result);
        }

        public IDataResult<Durum> GetByDurumAdi(string durumAdi)
        {
            var result = _durumDal.Get(d => d.DurumAdi == durumAdi);
            return new SuccessDataResult<Durum>(result);
        }

        public IDataResult<Durum> GetById(int id)
        {
            var result = _durumDal.Get(d => d.Id == id);
            return new SuccessDataResult<Durum>(result);
        }

        public IResult Update(Durum durum)
        {
            _durumDal.Update(durum);
            return new SuccessResult();
        }
    }
}
