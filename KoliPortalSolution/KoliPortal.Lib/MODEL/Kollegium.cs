using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoliPortal.Lib.MODEL
{
    public class Kollegium
    {
        [Key]
        public int ID { get; set; }
        public string KollegiumNev { get; set; }
    }
}
