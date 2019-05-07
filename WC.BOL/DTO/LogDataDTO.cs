using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.BOL.DTO
{
    public class LogDataDTO
    {
        [Key]
        public int LogId { get; set; }

        public double Summary { get; set; }

        public double FirstVariable { get; set; }

        public string Sign { get; set; }

        public double SecondVariable { get; set; }

        public DateTime LogTime { get; set; }
    }
}
