using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("Adresler")]
    public class Adres:IEntity
    {
        public int Id { get; set; }
        public string AdresNo { get; set; }
        public int CaddeId { get; set; }
        public Cadde? Cadde { get; set; }
        public int SokakId { get; set; }
        public Sokak? Sokak { get; set; }
        public int DisKapiNo { get; set; }
        public int IcKapiNo { get; set; }
        public int Ada { get; set; }
        public int Parsel { get; set; }
        public ICollection<Firma>? Firmas { get; set; }
    }
}
