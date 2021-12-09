using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafeAdisyon.Data.Abstract;

namespace KafeAdisyon.Data.Models
{
    [Table("SiparisDetaylari")]
    public class SiparisDetay:BaseEntity,IKey<int>
    {
        public int Id { get; set; }
        [ForeignKey(nameof(UrunID))]
        public Urun Urun { get; set; } 
        public int UrunID { get; set; }
        [ForeignKey(nameof(SiparisId))]
        public Siparis  Siparis { get; set; }
        public int SiparisId { get; set; }

        public int Adet { get; set; } = 0;
        public decimal Fiyat { get; set; }=0;
        public decimal AraToplam { get; set; } = 0;
    }
}
