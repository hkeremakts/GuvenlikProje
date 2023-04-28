using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface IFirmaYetkiliService
    {
        IDataResult<List<FirmaYetkili>> GetAll();
        IDataResult<FirmaYetkili> GetById(int id);
        IDataResult<FirmaYetkili> GetByFirmaYetkiliAdi(string firmaYetkiliAdi);
        IResult Add(FirmaYetkili firmaYetkili);
        IResult Delete(FirmaYetkili firmaYetkili);
        IResult Update(FirmaYetkili firmaYetkili);
    }
}
