namespace tp6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArtMartials1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArtMartials", "Samourai_Id", "dbo.Samourais");
            DropIndex("dbo.Samourais", new[] { "Arme_Id" });
            DropIndex("dbo.ArtMartials", new[] { "Samourai_Id" });
            RenameColumn(table: "dbo.Armes", name: "Arme_Id", newName: "Samourai_Id");
            AddColumn("dbo.Samourais", "ArtMartials_Id", c => c.Int());
            CreateIndex("dbo.Armes", "Samourai_Id");
            CreateIndex("dbo.Samourais", "ArtMartials_Id");
            AddForeignKey("dbo.Samourais", "ArtMartials_Id", "dbo.ArtMartials", "Id");
            DropColumn("dbo.Samourais", "Arme_Id");
            DropColumn("dbo.ArtMartials", "Samourai_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArtMartials", "Samourai_Id", c => c.Int());
            AddColumn("dbo.Samourais", "Arme_Id", c => c.Int());
            DropForeignKey("dbo.Samourais", "ArtMartials_Id", "dbo.ArtMartials");
            DropIndex("dbo.Samourais", new[] { "ArtMartials_Id" });
            DropIndex("dbo.Armes", new[] { "Samourai_Id" });
            DropColumn("dbo.Samourais", "ArtMartials_Id");
            RenameColumn(table: "dbo.Armes", name: "Samourai_Id", newName: "Arme_Id");
            CreateIndex("dbo.ArtMartials", "Samourai_Id");
            CreateIndex("dbo.Samourais", "Arme_Id");
            AddForeignKey("dbo.ArtMartials", "Samourai_Id", "dbo.Samourais", "Id");
        }
    }
}
