using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeAdisyon.Data.Abstract
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate  { get; set; }
        public DateTime? DeletedDate  { get; set; }
        public bool IsDeleted { get; set; } = false;


    }

}
