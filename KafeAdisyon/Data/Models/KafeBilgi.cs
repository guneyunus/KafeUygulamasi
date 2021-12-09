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
    [Table("KafeBilgi")]
    public class KafeBilgi:BaseEntity,IKey<int>
    {
        public int Id { get; set; }
        public byte[] Logo { get; set; }

        [Required, StringLength(50)]
        public string Ad { get; set; }
        public ICollection<Kat> Katlar { get; set; } = new HashSet<Kat>();
        
    }
}
