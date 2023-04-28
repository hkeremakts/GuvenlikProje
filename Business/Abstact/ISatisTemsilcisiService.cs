using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface ISatisTemsilcisiService
    {
        IDataResult<List<SatisTemsilcisi>> GetAll();
        IDataResult<SatisTemsilcisi> GetById(int id);
        IDataResult<SatisTemsilcisi> GetBySatisTemsilcisiAdi(string satisTemsilcisiAdi);
        IResult Add(SatisTemsilcisi satisTemsilcisi);
        IResult Delete(SatisTemsilcisi satisTemsilcisi);
        IResult Update(SatisTemsilcisi satisTemsilcisi);
    }
}
