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
    [Table("Kategoriler")]
   public class Kategori:BaseEntity,IKey<int>
    {
        public int Id { get; set; }
        [Required,StringLength(50)]
        public string Ad { get; set; }
        [StringLength(255)]
        public string? Aciklama { get; set; }
        public byte[] Fotograf { get; set; }

        public ICollection<Urun> Urunler { get; set; } = new HashSet<Urun>();
    }
}
