using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("Durumlar")]
    public class Durum:IEntity
    {
        public int Id { get; set; }
        public string DurumAdi { get; set; }
        public ICollection<Firma>? Firmas { get; set; }
    }
}
