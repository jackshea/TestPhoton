namespace TestPhotonModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestPhotonModelUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        PasswordMd5 = c.String(),
                        LastLoginin = c.DateTime(nullable: false),
                        Enable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accounts");
        }
    }
}
