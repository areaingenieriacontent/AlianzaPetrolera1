namespace AlianzaPetrolera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ciudadp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Ubic_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Ubic_Id");
        }
    }
}
