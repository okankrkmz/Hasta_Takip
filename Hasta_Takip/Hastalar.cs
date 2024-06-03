using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hasta_Takip
{
    public class Hastalar
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TC { get; set; }
        public DateTime BirthDate { get; set; }
        public string Telefon { get; set; }
        public string DoktorAdi { get; set; }
        public string HastaNotlari { get; set; }
        public DateTime HastaKayit { get; set; }
        public DateTime HastaTaburcu { get; set; }
        public string Hastalık { get; set; }
        public string HastalıkGecmisi { get; set; }
        public int Boy { get; set; }
        public int Kilo { get; set; }


    }
}
