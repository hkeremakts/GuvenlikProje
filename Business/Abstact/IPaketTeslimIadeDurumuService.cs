using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface IPaketTeslimIadeDurumuService
    {
        IDataResult<List<PaketTeslimIadeDurumu>> GetAll();
        IDataResult<PaketTeslimIadeDurumu> GetById(int id);
        IDataResult<PaketTeslimIadeDurumu> GetByPaketTeslimIadeDurumuAdi(string paketTeslimIadeDurumuAdi);
        IResult Add(PaketTeslimIadeDurumu paketTeslimIadeDurumu);
        IResult Delete(PaketTeslimIadeDurumu paketTeslimIadeDurumu);
        IResult Update(PaketTeslimIadeDurumu paketTeslimIadeDurumu);
    }
}
