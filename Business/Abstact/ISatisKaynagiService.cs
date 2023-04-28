using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface ISatisKaynagiService
    {
        IDataResult<List<SatisKaynagi>> GetAll();
        IDataResult<SatisKaynagi> GetById(int id);
        IDataResult<SatisKaynagi> GetBySatisKaynagiAdi(string satisKaynagiAdi);
        IResult Add(SatisKaynagi satisKaynagi);
        IResult Delete(SatisKaynagi satisKaynagi);
        IResult Update(SatisKaynagi satisKaynagi);
    }
}
