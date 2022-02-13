namespace DepartmanPersonelYonetimi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        DepartmanId = c.Int(nullable: false, identity: true),
                        DepartmanAd = c.String(),
                    })
                .PrimaryKey(t => t.DepartmanId);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        PersonelId = c.Int(nullable: false, identity: true),
                        PersonelAd = c.String(),
                        PersonelSoyad = c.String(),
                        DepartmanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelId)
                .ForeignKey("dbo.Departmen", t => t.DepartmanId, cascadeDelete: true)
                .Index(t => t.DepartmanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personels", "DepartmanId", "dbo.Departmen");
            DropIndex("dbo.Personels", new[] { "DepartmanId" });
            DropTable("dbo.Personels");
            DropTable("dbo.Departmen");
        }
    }
}
