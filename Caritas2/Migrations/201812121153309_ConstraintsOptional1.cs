namespace Caritas2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConstraintsOptional1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Korisnici", "ImeKorisnika", c => c.String(nullable: false));
            AlterColumn("dbo.Korisnici", "PrezimeKorisnika", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Korisnici", "PrezimeKorisnika", c => c.String());
            AlterColumn("dbo.Korisnici", "ImeKorisnika", c => c.String());
        }
    }
}
