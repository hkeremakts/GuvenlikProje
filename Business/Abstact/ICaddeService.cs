using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface ICaddeService
    {
        IDataResult<List<Cadde>> GetAll();
        IDataResult<Cadde> GetById(int id);
        IDataResult<Cadde> GetByCaddeAdi(string caddeAdi);
        IResult Add(Cadde cadde);
        IResult Delete(Cadde cadde);
        IResult Update(Cadde cadde);
    }
}
