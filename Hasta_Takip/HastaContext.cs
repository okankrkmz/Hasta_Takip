using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hasta_Takip
{
    public class HastaContext : DbContext
    {
        public HastaContext()
        {
            Database.Connection.ConnectionString = "server=.;database=HospitalDB;uid=sa;pwd=123";
        }
        public DbSet<Hastalar> Hastalar { get; set; }
        public DbSet<Doktorlar> Doktorlar { get; set; }
        public DbSet<Kullanıcılar> Kullanıcılar { get; set; }

    }
}
