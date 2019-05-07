namespace WC.DAL.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LogData
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
