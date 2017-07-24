namespace SystemAdminDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLogonAttempt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogonAttempts",
                c => new
                    {
                        LogonAttemptID = c.Int(nullable: false, identity: true),
                        LogonDateTime = c.DateTime(nullable: false),
                        LogonSuccessful = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LogonAttemptID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogonAttempts");
        }
    }
}
