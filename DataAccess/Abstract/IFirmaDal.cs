using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IFirmaDal:IEntityRepository<Firma>
    {
        List<FirmaSearchDTO> GetFirmaSearchDTOs(string firmaAdi);
        FirmaComponentsDTO GetFirmaComponentsDTO(Expression<Func<FirmaComponentsDTO, bool>> filter);
        List<FirmaComponentsDTO> GetAllFirmaComponentsDTOs(Expression<Func<FirmaComponentsDTO, bool>> filter=null);

    }
}
