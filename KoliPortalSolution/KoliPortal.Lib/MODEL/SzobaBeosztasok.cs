using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoliPortal.Lib.MODEL
{
    public class SzobaBeosztasok
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RoomID { get; set; }
        public DateTime BekoltozesDatum { get; set; }
        public DateTime VarhatoKikoltozes { get; set; }
        public DateTime TenylegesKikoltozes { get; set; }

    }
}
