namespace Caritas2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Constraints : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.KorisnikModels", newName: "Korisnici");
            AlterColumn("dbo.Korisnici", "OIB", c => c.String(maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Korisnici", "OIB", c => c.String());
            RenameTable(name: "dbo.Korisnici", newName: "KorisnikModels");
        }
    }
}
