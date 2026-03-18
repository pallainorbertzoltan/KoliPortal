using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoliPortal.Lib.MODEL
{
    public class Penzugyek
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int TipusID { get; set; }
        public decimal Osszeg { get; set; }
        public DateTime Esedekesseg { get; set; }
        public DateTime? BefizetesDatum { get; set; }
        public string? Statusz { get; set; }
    }
}
