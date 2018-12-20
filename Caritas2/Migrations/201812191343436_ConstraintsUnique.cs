namespace Caritas2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConstraintsUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PonasanjeModels", "NazivPonasanja", c => c.String(maxLength: 255));
            AlterColumn("dbo.SpolModels", "NazivSpola", c => c.String(maxLength: 255));
            CreateIndex("dbo.PonasanjeModels", "NazivPonasanja", unique: true);
            CreateIndex("dbo.SpolModels", "NazivSpola", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.SpolModels", new[] { "NazivSpola" });
            DropIndex("dbo.PonasanjeModels", new[] { "NazivPonasanja" });
            AlterColumn("dbo.SpolModels", "NazivSpola", c => c.String());
            AlterColumn("dbo.PonasanjeModels", "NazivPonasanja", c => c.String());
        }
    }
}
