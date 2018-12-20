namespace Caritas2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KorisnikModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        ImeKorisnika = c.String(),
                        PrezimeKorisnika = c.String(),
                        OIB = c.String(),
                        EmailKorisnika = c.String(),
                        PostanskiBroj = c.Int(nullable: true),
                        DatumRodjenja = c.DateTime(nullable: true),
                        PonasanjeID = c.Int(),
                        SpolID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PonasanjeModels", t => t.PonasanjeID)
                .ForeignKey("dbo.SpolModels", t => t.SpolID)
                .Index(t => t.PonasanjeID)
                .Index(t => t.SpolID);
            
            CreateTable(
                "dbo.PonasanjeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NazivPonasanja = c.String(),
                        AktivnostPonasanja = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpolModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NazivSpola = c.String(),
                        AktivnostSpola = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KorisnikModels", "SpolID", "dbo.SpolModels");
            DropForeignKey("dbo.KorisnikModels", "PonasanjeID", "dbo.PonasanjeModels");
            DropIndex("dbo.KorisnikModels", new[] { "SpolID" });
            DropIndex("dbo.KorisnikModels", new[] { "PonasanjeID" });
            DropTable("dbo.SpolModels");
            DropTable("dbo.PonasanjeModels");
            DropTable("dbo.KorisnikModels");
        }
    }
}
