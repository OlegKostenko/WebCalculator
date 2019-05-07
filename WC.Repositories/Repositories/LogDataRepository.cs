using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Reposirories.Common;
using WC.DAL.DbLayer;

namespace WC.Repositories.Repositories
{
    public class LogDataRepository : GenericRepository<LogData>
    {
        public LogDataRepository(DbContext context) : base(context) { }
    }
}
