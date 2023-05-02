using Business.Abstact;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
            _firmaDal = firmaDal;
        }
        [ValidationAspect(typeof(FirmaValidator))]
        public IResult Add(Firma firma)
        {
            var result = BusinessRules.Run(
                CheckIfFirmaAlreadyExists(firma.FirmaAdi),
                CheckIfAnyAdresComponentIsNull(firma),
                CheckIfAdresNoExists(firma.AdresNo));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            _firmaDal.Add(firma);
            return new SuccessResult(BusinessMessages.FirmaAdded);
        }

        public IResult Delete(Firma firma)
        {
            var result = BusinessRules.Run(CheckIfFirmaExists(firma.Id));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
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

        public IDataResult<List<FirmaSearchDTO>> GetByFirmaAdiContains(string firmaAdi)
        {
            var result = BusinessRules.Run(CheckIfFirmaExists(firmaAdi));
            if (result != null)
            {
                return new ErrorDataResult<List<FirmaSearchDTO>>(result.Message);
            }
            var firmas = _firmaDal.GetFirmaSearchDTOs(firmaAdi);
            return new SuccessDataResult<List<FirmaSearchDTO>>(firmas);
        }

        public IDataResult<Firma> GetById(int id)
        {
            var result = BusinessRules.Run(CheckIfFirmaExists(id));
            if (result != null)
            {
                return new ErrorDataResult<Firma>(result.Message);
            }
            var firma = _firmaDal.Get(f => f.Id == id);
            return new SuccessDataResult<Firma>(firma);
        }

        public IDataResult<FirmaComponentsDTO> GetFirmaComponentsById(int id)
        {
            var result = BusinessRules.Run(CheckIfFirmaComponentsExists(id));
            if (result != null)
            {
                return new ErrorDataResult<FirmaComponentsDTO>(result.Message);
            }
            var firmaComponents = _firmaDal.GetFirmaComponentsDTO(f => f.FirmaId == id);
            return new SuccessDataResult<FirmaComponentsDTO>(firmaComponents);
        }
        [ValidationAspect(typeof(FirmaValidator))]
        public IResult Update(Firma firma)
        {
            var result = BusinessRules.Run(
                CheckIfFirmaAlreadyExists(firma.FirmaAdi),
                CheckIfAnyAdresComponentIsNull(firma),
                CheckIfAdresNoExists(firma.AdresNo));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            _firmaDal.Update(firma);
            return new SuccessResult();
        }
        private IResult CheckIfFirmaExists(string firmaAdi)
        {
            var result = _firmaDal.GetFirmaSearchDTOs(firmaAdi);
            if (result.Count < 1)
            {
                return new ErrorResult(BusinessMessages.FirmaDoesNotExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfFirmaExists(int id)
        {
            var result = _firmaDal.Get(f => f.Id == id);
            if (result == null)
            {
                return new ErrorResult(BusinessMessages.FirmaDoesNotExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfFirmaComponentsExists(int id)
        {
            var result = _firmaDal.GetFirmaComponentsDTO(f => f.FirmaId == id);
            if (result == null)
            {
                return new ErrorResult(BusinessMessages.FirmaDoesNotExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfFirmaAlreadyExists(string firmaAdi)
        {
            var result = _firmaDal.Get(f => f.FirmaAdi == firmaAdi);
            if (result != null)
            {
                return new ErrorResult(BusinessMessages.FirmaAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfAnyAdresComponentIsNull(Firma firma)
        {
            var adresComponents = new List<string>();
            adresComponents.Add(firma.IcKapiNo.ToString());
            adresComponents.Add(firma.DisKapiNo.ToString());
            adresComponents.Add(firma.AdresNo);
            adresComponents.Add(firma.Ada.ToString());
            adresComponents.Add(firma.Parsel.ToString());
            foreach (var item in adresComponents)
            {
                if (item.Count() < 1)
                {
                    return new ErrorResult(BusinessMessages.AdresIsNull);
                }
            }
            return new SuccessResult();
        }
        private IResult CheckIfAdresNoExists(string adresNo)
        {
            var result = _firmaDal.Get(f => f.AdresNo == adresNo);
            if (result != null)
            {
                return new ErrorResult(BusinessMessages.AdresNoExists);
            }
            return new SuccessResult();
        }

    }
}
