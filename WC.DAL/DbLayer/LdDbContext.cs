namespace WC.DAL.DbLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LdDbContext : DbContext
    {
        public LdDbContext()
            : base("name=LdDbContext")
        {
        }

        public virtual DbSet<LogData> LogDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
