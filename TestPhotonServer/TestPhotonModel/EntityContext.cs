using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPhotonModel.Entities;

namespace TestPhotonModel
{
    public class EntityContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}
