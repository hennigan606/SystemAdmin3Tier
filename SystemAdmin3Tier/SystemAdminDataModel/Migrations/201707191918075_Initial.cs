namespace SystemAdminDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccessGroups",
                c => new
                    {
                        UserAccessGroupID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.UserAccessGroupID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsBanned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.ServiceRequests",
                c => new
                    {
                        ServiceRequestID = c.Int(nullable: false, identity: true),
                        UserFullName = c.String(),
                        RequestType = c.String(),
                        Details = c.String(),
                        AdminOperator = c.String(),
                        AdditionalInfo = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceRequestID);
            
            CreateTable(
                "dbo.UserUserAccessGroups",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        UserAccessGroup_UserAccessGroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.UserAccessGroup_UserAccessGroupID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.UserAccessGroups", t => t.UserAccessGroup_UserAccessGroupID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.UserAccessGroup_UserAccessGroupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserUserAccessGroups", "UserAccessGroup_UserAccessGroupID", "dbo.UserAccessGroups");
            DropForeignKey("dbo.UserUserAccessGroups", "User_UserID", "dbo.Users");
            DropIndex("dbo.UserUserAccessGroups", new[] { "UserAccessGroup_UserAccessGroupID" });
            DropIndex("dbo.UserUserAccessGroups", new[] { "User_UserID" });
            DropTable("dbo.UserUserAccessGroups");
            DropTable("dbo.ServiceRequests");
            DropTable("dbo.Users");
            DropTable("dbo.UserAccessGroups");
        }
    }
}
