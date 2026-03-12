using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoliPortal.Lib.MODEL
{
    public class DiakAdatok
    {
        [Key]
        public int UserID { get; set; }
        public string? Evfolyam { get; set; }
        public string? Lakcim { get; set; }
    }
}
