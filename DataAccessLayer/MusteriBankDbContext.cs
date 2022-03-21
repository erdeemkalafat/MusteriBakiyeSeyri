using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class MusteriBankDbContext:DbContext
    {
        public MusteriBankDbContext(DbContextOptions<MusteriBankDbContext> options) : base(options) {}

        public DbSet<musteri_tanim_table> musteri_tanim_table { get; set; }
        public DbSet<musteri_fatura_table> musteri_fatura_table { get; set; }
        public DbSet<SPSonuc> SPSonuclar { get; set; }

    }
}
