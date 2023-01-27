namespace mvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kargoBilgi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.kargoDetays",
                c => new
                    {
                        kargoDetayId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 200, unicode: false),
                        takipKodu = c.String(maxLength: 10, unicode: false),
                        personel = c.String(maxLength: 20, unicode: false),
                        alici = c.String(maxLength: 20, unicode: false),
                        tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.kargoDetayId);
            
            CreateTable(
                "dbo.kargoTakips",
                c => new
                    {
                        kargoTakipId = c.Int(nullable: false, identity: true),
                        TakipKod = c.String(maxLength: 20, unicode: false),
                        Aciklama = c.String(maxLength: 200, unicode: false),
                        tarihZaman = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.kargoTakipId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.kargoTakips");
            DropTable("dbo.kargoDetays");
        }
    }
}
