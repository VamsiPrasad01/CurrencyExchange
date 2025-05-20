namespace CurrencyExchangeBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        CurrencyCode = c.String(),
                        Amount = c.Double(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        PLNBalance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrencyCode = c.String(),
                        Amount = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wallets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "UserId", "dbo.Users");
            DropIndex("dbo.Wallets", new[] { "UserId" });
            DropIndex("dbo.Transactions", new[] { "UserId" });
            DropTable("dbo.Wallets");
            DropTable("dbo.Users");
            DropTable("dbo.Transactions");
        }
    }
}
