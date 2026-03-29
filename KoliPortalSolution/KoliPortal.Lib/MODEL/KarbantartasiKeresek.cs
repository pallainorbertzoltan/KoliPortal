using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoliPortal.Lib.MODEL
{
    public class KarbantartasiKeresek
    {
        [Key]
        public int ID { get; set; }
        public int BejelentoID { get; set; }
        public string? Leiras { get; set; }
        public int StatuszID { get; set; }
        public DateTime LetrehozasDatum { get; set; }
    }
}
