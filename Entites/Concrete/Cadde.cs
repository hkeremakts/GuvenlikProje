using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("Caddeler")]
    public class Cadde:IEntity
    {
        public int Id { get; set; }
        public string CaddeAdi { get; set; }
        public ICollection<Firma>? Firmas { get; set; }
    }
}
