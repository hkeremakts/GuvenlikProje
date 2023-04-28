using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface IFarkliFirmaService
    {
        IDataResult<List<FarkliFirma>> GetAll();
        IDataResult<FarkliFirma> GetById(int id);
        IDataResult<FarkliFirma> GetByFarkliFirmaAdi(string farkliFirmaAdi);
        IResult Add(FarkliFirma farkliFirma);
        IResult Delete(FarkliFirma farkliFirma);
        IResult Update(FarkliFirma farkliFirma);
    }
}
