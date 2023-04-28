using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface IAdresService
    {
        IDataResult<List<Adres>> GetAll();
        IDataResult<Adres> GetById(int id);
        IDataResult<Adres> GetByAdresNo(string adresNo);
        IResult Add(Adres adres);
        IResult Delete(Adres adres);
        IResult Update(Adres adres);
    }
}
