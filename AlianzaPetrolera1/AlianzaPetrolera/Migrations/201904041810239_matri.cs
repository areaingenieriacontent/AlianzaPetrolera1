namespace AlianzaPetrolera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matri : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Cate_Id = c.Int(nullable: false, identity: true),
                        Cate_Name = c.String(),
                    })
                .PrimaryKey(t => t.Cate_Id);
            
            CreateTable(
                "dbo.Inscripcions",
                c => new
                    {
                        Insc_ID = c.Int(nullable: false, identity: true),
                        Pers_Doc = c.String(),
                        Insc_NomEst = c.String(),
                        Insc_ApeEst = c.String(),
                        Insc_DocEst = c.String(),
                        Insc_FechInsc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Insc_ID);
            
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        Matri_Id = c.Int(nullable: false, identity: true),
                        Insc_Id = c.Int(nullable: false),
                        Peri_Id = c.Int(nullable: false),
                        Cate_Id = c.String(),
                        Matr_Fecha = c.DateTime(nullable: false),
                        Matri_Esta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Matri_Id)
                .ForeignKey("dbo.Inscripcions", t => t.Insc_Id, cascadeDelete: true)
                .Index(t => t.Insc_Id);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Pers_Cod = c.String(nullable: false, maxLength: 128),
                        Pers_NickNom = c.String(),
                        Pers_Pwd = c.String(),
                        Pers_Nom = c.String(),
                        Pers_Lstn1 = c.String(),
                        Pers_Lstn2 = c.String(),
                        Pers_TypeDoc = c.Int(nullable: false),
                        Pers_Doc = c.String(),
                        Pers_Birth = c.DateTime(),
                        Pers_Dir = c.String(),
                        Pers_Tel1 = c.String(),
                        Pers_Tel2 = c.String(),
                        Pers_Mail1 = c.String(),
                        Pers_Mail2 = c.String(),
                        Pers_Ingreso = c.DateTime(),
                        Pers_TotalPoints = c.Int(nullable: false),
                        Ubic_Id = c.Int(nullable: false),
                        Rolp_Id = c.Int(nullable: false),
                        Padre_Id = c.String(),
                    })
                .PrimaryKey(t => t.Pers_Cod);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Pers_Nom = c.String(),
                        Pers_Lstn1 = c.String(),
                        Pers_Lstn2 = c.String(),
                        Pers_TypeDoc = c.Int(nullable: false),
                        Pers_Doc = c.String(),
                        RolP_Id = c.Int(nullable: false),
                        Pers_Birth = c.DateTime(nullable: false),
                        Pers_Dir = c.String(),
                        Pers_Cel = c.String(),
                        Pers_Tel = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Persona_Pers_Cod = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.Persona_Pers_Cod)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Persona_Pers_Cod);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ReciboCajas",
                c => new
                    {
                        Reci_Id = c.Int(nullable: false, identity: true),
                        Costo_Matri = c.Int(nullable: false),
                        Costo_Poli = c.Int(nullable: false),
                        Costo_Unif = c.Int(nullable: false),
                        Costo_Mensu = c.Int(nullable: false),
                        Matr_Fecha = c.DateTime(nullable: false),
                        Matri_Esta = c.Int(nullable: false),
                        Matri_CosTota = c.Single(),
                    })
                .PrimaryKey(t => t.Reci_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Ubicacions",
                c => new
                    {
                        Ubic_Id = c.Int(nullable: false, identity: true),
                        Ubic_Name = c.String(),
                    })
                .PrimaryKey(t => t.Ubic_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUsers", "Persona_Pers_Cod", "dbo.Personas");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Matriculas", "Insc_Id", "dbo.Inscripcions");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Persona_Pers_Cod" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Matriculas", new[] { "Insc_Id" });
            DropTable("dbo.Ubicacions");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ReciboCajas");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Personas");
            DropTable("dbo.Matriculas");
            DropTable("dbo.Inscripcions");
            DropTable("dbo.Categorias");
        }
    }
}
