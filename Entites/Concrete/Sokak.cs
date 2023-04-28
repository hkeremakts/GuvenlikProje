using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("Sokaklar")]
    public class Sokak:IEntity
    {
        public int Id { get; set; }
        public string SokakAdi { get; set; }
        public ICollection<Adres>? Adress { get; set; }
    }
}
