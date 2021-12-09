using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeAdisyon.Data.Abstract
{
    public interface IKey<TId>
    {
        [Key]
        public TId Id { get; set; }
    }
}
