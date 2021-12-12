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
    [Table("Siparisler")]
    public class Siparis:BaseEntity,IKey<int>
    {
        public int Id { get; set; }

        public int GetSiparisId { get; set; }
        public DateTime SiparisTarihi { get; set; } = DateTime.Now;
        [Column(TypeName = "smalldatetime")]
        public DateTime? UlasmaTarihi { get; set; }

        public ICollection<SiparisDetay> SiparisDetaylar { get; set; } = new HashSet<SiparisDetay>();
        
        [ForeignKey(nameof(MasaId))]
        public Masa Masa { get; set; }
        public int MasaId { get; set; }
    }
}
