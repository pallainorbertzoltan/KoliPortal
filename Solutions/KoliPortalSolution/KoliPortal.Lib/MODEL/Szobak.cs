using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoliPortal.Lib.MODEL
{
    public class Szobak
    {
        [Key]
        public int ID { get; set; }
        public string? Szobaszam { get; set; }
        public int Emelet { get; set; }
        public int FerohelyMax { get; set; }
    }
}
