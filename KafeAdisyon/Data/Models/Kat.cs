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
    [Table("Katlar")]
    public class Kat : BaseEntity,IKey<int>
    {
        public int Id { get; set; }

        [Required,StringLength(10)]
        public string Ad { get; set; }

        
        public int Sira { get; set; } = 0;
        [Required,StringLength(2)]
        public string Kod { get; set; }
        public ICollection<Masa> Masalar { get; set; } = new HashSet<Masa>();
       
        [ForeignKey(nameof(KafeBilgiId))]
        public KafeBilgi KafeBilgi { get; set; }
       
        public int KafeBilgiId { get; set; }
        
    }
}
