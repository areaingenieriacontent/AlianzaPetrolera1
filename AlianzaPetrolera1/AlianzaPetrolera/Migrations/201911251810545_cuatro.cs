namespace AlianzaPetrolera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cuatro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReciboCajas", "Mes_Pago", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReciboCajas", "Abonos_Otros", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReciboCajas", "Abonos_Otros");
            DropColumn("dbo.ReciboCajas", "Mes_Pago");
        }
    }
}
