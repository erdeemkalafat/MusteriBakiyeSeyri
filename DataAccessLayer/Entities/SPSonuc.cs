using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [Keyless]
    public class SPSonuc
    {
        public DateTime FATURA_TARIHI { get; set; }
        public int MUSTERI_ID { get; set; }
        public decimal toplamBorc { get; set; }
    }
}
