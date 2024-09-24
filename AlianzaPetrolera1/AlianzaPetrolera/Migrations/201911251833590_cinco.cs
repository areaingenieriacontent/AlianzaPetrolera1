namespace AlianzaPetrolera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cinco : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReciboCajas", "Mes_Pago", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReciboCajas", "Mes_Pago", c => c.DateTime(nullable: false));
        }
    }
}
