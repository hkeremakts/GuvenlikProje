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
    public class SokakManager : ISokakService
    {
        ISokakDal _sokakDal;
        public SokakManager(ISokakDal sokakDal)
        {
            _sokakDal=sokakDal;
        }
        public IResult Add(Sokak sokak)
        {
            _sokakDal.Add(sokak);
            return new SuccessResult();
        }

        public IResult Delete(Sokak sokak)
        {
            _sokakDal.Delete(sokak);
            return new SuccessResult();
        }

        public IDataResult<List<Sokak>> GetAll()
        {
            var result = _sokakDal.GetAll();
            return new SuccessDataResult<List<Sokak>>(result);
        }

        public IDataResult<Sokak> GetById(int id)
        {
            var result = _sokakDal.Get(s => s.Id == id);
            return new SuccessDataResult<Sokak>(result);
        }

        public IDataResult<Sokak> GetBySokakAdi(string sokakAdi)
        {
            var result = _sokakDal.Get(s => s.SokakAdi == sokakAdi);
            return new SuccessDataResult<Sokak>(result);
        }

        public IResult Update(Sokak sokak)
        {
            _sokakDal.Update(sokak);
            return new SuccessResult();
        }
    }
}
