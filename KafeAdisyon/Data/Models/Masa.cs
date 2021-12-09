using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafeAdisyon.Data.Abstract;

namespace KafeAdisyon.Data.Models
{
    [Table("Masalar")]
    public class Masa:BaseEntity,IKey<int>
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Ad { get; set; }
        public int Sira { get; set; }
        public bool DoluMU { get; set; } = false;

        [ForeignKey(nameof(KatId))]
        public Kat Kat { get; set; } 
        public int KatId { get; set; }

        public ICollection<Siparis> Siparisler { get; set; } = new HashSet<Siparis>();
    }
}
