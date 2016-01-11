using System.Data.Entity;
using TestPhotonModel.Entities;

namespace TestPhotonModel
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("EntityContext")
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}