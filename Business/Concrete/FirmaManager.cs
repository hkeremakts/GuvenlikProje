using Business.Abstact;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FirmaManager : IFirmaService
    {
        IFirmaDal _firmaDal;
        public FirmaManager(IFirmaDal firmaDal)
        {
            _firmaDal= firmaDal;
        }
        public IResult Add(Firma firma)
        {
            _firmaDal.Add(firma);
            return new SuccessResult();
        }

        public IResult Delete(Firma firma)
        {
            _firmaDal.Delete(firma);
            return new SuccessResult();
        }

        public IDataResult<List<Firma>> GetAll()
        {
            var result = _firmaDal.GetAll();
            return new SuccessDataResult<List<Firma>>(result);
        }

        public IDataResult<List<FirmaComponentsDTO>> GetAllFirmaComponents()
        {
            var result = _firmaDal.GetAllFirmaComponentsDTOs();
            return new SuccessDataResult<List<FirmaComponentsDTO>>(result);
        }

        public IDataResult<Firma> GetByAdresId(int adresId)
        {
            var result = _firmaDal.Get(f => f.Id == adresId);
            return new SuccessDataResult<Firma>(result);
        }

        public IDataResult<List<FirmaSearchDTO>> GetByFirmaAdiContains(string firmaAdi)
        {
            var result = _firmaDal.GetFirmaSearchDTOs(firmaAdi);
            return new SuccessDataResult<List<FirmaSearchDTO>>(result);
        }

        public IDataResult<Firma> GetById(int id)
        {
            var result = _firmaDal.Get(f => f.Id == id);
            return new SuccessDataResult<Firma>(result);
        }

        public IDataResult<FirmaComponentsDTO> GetFirmaComponentsById(int id)
        {
            var result=_firmaDal.GetFirmaComponentsDTO(f=>f.FirmaId==id);
            return new SuccessDataResult<FirmaComponentsDTO>(result);
        }

        public IResult Update(Firma firma)
        {
            _firmaDal.Update(firma);
            return new SuccessResult();
        }
    }
}
