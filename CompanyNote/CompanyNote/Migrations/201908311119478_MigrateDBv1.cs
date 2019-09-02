namespace CompanyNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDBv1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notes", "CompanyId_Id", "dbo.Companies");
            DropIndex("dbo.Notes", new[] { "CompanyId_Id" });
            RenameColumn(table: "dbo.Notes", name: "CompanyId_Id", newName: "CompanyId");
            AlterColumn("dbo.Notes", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Notes", "CompanyId");
            AddForeignKey("dbo.Notes", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Notes", new[] { "CompanyId" });
            AlterColumn("dbo.Notes", "CompanyId", c => c.Int());
            RenameColumn(table: "dbo.Notes", name: "CompanyId", newName: "CompanyId_Id");
            CreateIndex("dbo.Notes", "CompanyId_Id");
            AddForeignKey("dbo.Notes", "CompanyId_Id", "dbo.Companies", "Id");
        }
    }
}
