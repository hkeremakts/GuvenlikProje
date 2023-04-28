using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface ISokakService
    {
        IDataResult<List<Sokak>> GetAll();
        IDataResult<Sokak> GetById(int id);
        IDataResult<Sokak> GetBySokakAdi(string sokakAdi);
        IResult Add(Sokak sokak);
        IResult Delete(Sokak sokak);
        IResult Update(Sokak sokak);
    }
}
