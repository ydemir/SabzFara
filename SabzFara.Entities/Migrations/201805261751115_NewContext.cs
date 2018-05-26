namespace SabzFara.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewContext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KasaHareketleri", "Tutar", c => c.Decimal(precision: 12, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KasaHareketleri", "Tutar", c => c.Decimal(nullable: false, precision: 12, scale: 2));
        }
    }
}
