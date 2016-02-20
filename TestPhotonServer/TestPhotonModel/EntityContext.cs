using System.Data.Entity;
using TestPhotonModel.Entities;

namespace TestPhotonModel
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("EntityContext")
        {
        }

        static EntityContext()
        {
            //数据库不存在时重新创建数据库
            Database.SetInitializer(new CreateDatabaseIfNotExists<EntityContext>());
            ////每次启动应用程序时创建数据库
            //Database.SetInitializer(new DropCreateDatabaseAlways<EntityContext>());
            ////模型更改时重新创建数据库
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EntityContext>());
            ////从不创建数据库
            //Database.SetInitializer<EntityContext>(null);
        }

        public DbSet<Account> Accounts { get; set; }
    }
}