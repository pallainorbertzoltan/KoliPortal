
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoliPortal.Lib.MODEL
{
    public class Felhasznalok
    {
        [Key]
        public int ID { get; set; }
        public string? Nev { get; set; }
        public string? Email { get; set; }
        public string? Jelszo { get; set; }
        public string? Telefonszam { get; set; }
        public int SzerepkorID { get; set; }
    }
}
