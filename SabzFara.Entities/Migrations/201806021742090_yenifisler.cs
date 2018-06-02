namespace SabzFara.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yenifisler : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fisler", "FaturaUnvani", c => c.String(maxLength: 50));
            AddColumn("dbo.Fisler", "CepTelefonu", c => c.String());
            AddColumn("dbo.Fisler", "Il", c => c.String(maxLength: 20));
            AddColumn("dbo.Fisler", "Ilce", c => c.String(maxLength: 20));
            AddColumn("dbo.Fisler", "Semt", c => c.String(maxLength: 20));
            AddColumn("dbo.Fisler", "Adres", c => c.String(maxLength: 100));
            AddColumn("dbo.Fisler", "VergiDairesi", c => c.String(maxLength: 30));
            AddColumn("dbo.Fisler", "VergiNo", c => c.String(maxLength: 15));
            DropColumn("dbo.StokHareketleri", "IndirimTutari");
            DropColumn("dbo.StokHareketleri", "ToplamTutar");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StokHareketleri", "ToplamTutar", c => c.Decimal(precision: 12, scale: 2));
            AddColumn("dbo.StokHareketleri", "IndirimTutari", c => c.Decimal(precision: 12, scale: 2));
            DropColumn("dbo.Fisler", "VergiNo");
            DropColumn("dbo.Fisler", "VergiDairesi");
            DropColumn("dbo.Fisler", "Adres");
            DropColumn("dbo.Fisler", "Semt");
            DropColumn("dbo.Fisler", "Ilce");
            DropColumn("dbo.Fisler", "Il");
            DropColumn("dbo.Fisler", "CepTelefonu");
            DropColumn("dbo.Fisler", "FaturaUnvani");
        }
    }
}
