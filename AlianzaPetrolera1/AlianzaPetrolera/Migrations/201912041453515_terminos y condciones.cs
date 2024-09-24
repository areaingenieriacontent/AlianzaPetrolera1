namespace AlianzaPetrolera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class terminosycondciones : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Term_Cond", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Term_Cond");
        }
    }
}
