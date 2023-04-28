using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface IDurumService
    {
        IDataResult<List<Durum>> GetAll();
        IDataResult<Durum> GetById(int id);
        IDataResult<Durum> GetByDurumAdi(string durumAdi);
        IResult Add(Durum durum);
        IResult Delete(Durum durum);
        IResult Update(Durum durum);
    }
}
