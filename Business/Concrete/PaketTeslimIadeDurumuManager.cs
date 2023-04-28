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
    public class PaketTeslimIadeDurumuManager : IPaketTeslimIadeDurumuService
    {
        IPaketTeslimIadeDurumuDal _paketTeslimIadeDurumu;
        public PaketTeslimIadeDurumuManager(IPaketTeslimIadeDurumuDal paketTeslimIadeDurumuDal)
        {
            _paketTeslimIadeDurumu= paketTeslimIadeDurumuDal;
        }
        public IResult Add(PaketTeslimIadeDurumu paketTeslimIadeDurumu)
        {
            _paketTeslimIadeDurumu.Add(paketTeslimIadeDurumu);
            return new SuccessResult();
        }

        public IResult Delete(PaketTeslimIadeDurumu paketTeslimIadeDurumu)
        {
            _paketTeslimIadeDurumu.Delete(paketTeslimIadeDurumu);
            return new SuccessResult();
        }

        public IDataResult<List<PaketTeslimIadeDurumu>> GetAll()
        {
            var result = _paketTeslimIadeDurumu.GetAll();
            return new SuccessDataResult<List<PaketTeslimIadeDurumu>>(result);
        }

        public IDataResult<PaketTeslimIadeDurumu> GetById(int id)
        {
            var result=_paketTeslimIadeDurumu.Get(p=>p.Id == id);
            return new SuccessDataResult<PaketTeslimIadeDurumu>(result);
        }

        public IDataResult<PaketTeslimIadeDurumu> GetByPaketTeslimIadeDurumuAdi(string paketTeslimIadeDurumuAdi)
        {
            var result = _paketTeslimIadeDurumu.Get(p => p.PaketTeslimIadeDurumuAdi == paketTeslimIadeDurumuAdi);
            return new SuccessDataResult<PaketTeslimIadeDurumu>(result);
        }

        public IResult Update(PaketTeslimIadeDurumu paketTeslimIadeDurumu)
        {
            _paketTeslimIadeDurumu.Update(paketTeslimIadeDurumu);
            return new SuccessResult();
        }
    }
}
