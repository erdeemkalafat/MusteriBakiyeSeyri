using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
   public class musteri_tanim_table
    {
        public int ID { get; set; }
        public string UNVAN { get; set; }

        public virtual ICollection<musteri_fatura_table> FATURA { get; set; }
    }
}
