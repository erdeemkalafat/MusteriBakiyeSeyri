using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class musteri_fatura_table
    {
        public int ID { get; set; }
        public int MUSTERI_ID { get; set; }
        public DateTime FATURA_TARIHI { get; set; }
        public Decimal FATURA_TUTARI { get; set; }

        public DateTime ODEME_TARIHI { get; set; }

        [ForeignKey("MUSTERI_ID")]
        public virtual musteri_tanim_table MUSTERI { get; set; }
    }
}
