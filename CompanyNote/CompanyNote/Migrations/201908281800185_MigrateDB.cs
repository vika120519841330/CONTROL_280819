namespace CompanyNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notes", "DateOfMeet", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notes", "DateOfMeet", c => c.Int(nullable: false));
        }
    }
}
