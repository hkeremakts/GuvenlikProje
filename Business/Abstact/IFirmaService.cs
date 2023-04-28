using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface IFirmaService
    {
        IDataResult<List<Firma>> GetAll();
        IDataResult<Firma> GetById(int id);
        IDataResult<Firma> GetByAdresId(int adresId);
        IDataResult<List<FirmaSearchDTO>> GetByFirmaAdiContains(string firmaAdi);
        IDataResult<List<FirmaComponentsDTO>> GetAllFirmaComponents();
        IDataResult<FirmaComponentsDTO> GetFirmaComponentsById(int id);
        IResult Add(Firma firma);
        IResult Delete(Firma firma);
        IResult Update(Firma firma);
    }
}
