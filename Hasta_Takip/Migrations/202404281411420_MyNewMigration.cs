namespace Hasta_Takip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyNewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doktorlars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Hastalars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        TC = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Telefon = c.String(),
                        DoktorAdi = c.String(),
                        HastaNotlari = c.String(),
                        HastaKayit = c.DateTime(nullable: false),
                        HastaTaburcu = c.DateTime(nullable: false),
                        Hastalık = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Kullanıcılar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kullanıcılar");
            DropTable("dbo.Hastalars");
            DropTable("dbo.Doktorlars");
        }
    }
}
