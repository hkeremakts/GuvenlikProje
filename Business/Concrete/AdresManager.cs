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
    public class AdresManager : IAdresService
    {
        IAdresDal _adresDal;
        public AdresManager(IAdresDal adresDal)
        {
            _adresDal = adresDal;
        }
        public IResult Add(Adres adres)
        {
            _adresDal.Add(adres);
            return new SuccessResult();
        }

        public IResult Delete(Adres adres)
        {
            _adresDal.Delete(adres);
            return new SuccessResult();
        }

        public IDataResult<List<Adres>> GetAll()
        {
            var result = _adresDal.GetAll();
            return new SuccessDataResult<List<Adres>>(result);
        }

        public IDataResult<Adres> GetByAdresNo(string adresNo)
        {
            var result = _adresDal.Get(a => a.AdresNo == adresNo);
            return new SuccessDataResult<Adres>(result);
        }

        public IDataResult<Adres> GetById(int id)
        {
            var result = _adresDal.Get(a => a.Id == id);
            return new SuccessDataResult<Adres>(result);
        }

        public IResult Update(Adres adres)
        {
            _adresDal.Update(adres);
            return new SuccessResult();
        }
    }
}
