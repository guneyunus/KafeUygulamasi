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
    [Table("Urunler")]
    public class Urun : BaseEntity, IKey<int>
    {
        public int Id { get; set; }
        [Required,StringLength(30)]
        public string Ad { get; set; }

        public decimal Fiyat { get; set; } = 0;
        public byte[] Fotograf { get; set; }
       
        [ForeignKey(nameof(KategoriId))]
        public Kategori Kategori { get; set; }
        
        public int KategoriId { get; set; }

        public ICollection<SiparisDetay> SiparisDetaylar { get; set; } = new HashSet<SiparisDetay>();
    }
}
