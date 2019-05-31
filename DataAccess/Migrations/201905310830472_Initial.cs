namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_M_Item", "Supplier_Id", "dbo.TB_M_Supplier");
            DropIndex("dbo.TB_M_Item", new[] { "Supplier_Id" });
            AlterColumn("dbo.TB_M_Item", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.TB_M_Item", "Supplier_Id", c => c.Int());
            CreateIndex("dbo.TB_M_Item", "Supplier_Id");
            AddForeignKey("dbo.TB_M_Item", "Supplier_Id", "dbo.TB_M_Supplier", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_M_Item", "Supplier_Id", "dbo.TB_M_Supplier");
            DropIndex("dbo.TB_M_Item", new[] { "Supplier_Id" });
            AlterColumn("dbo.TB_M_Item", "Supplier_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.TB_M_Item", "Price", c => c.Double(nullable: false));
            CreateIndex("dbo.TB_M_Item", "Supplier_Id");
            AddForeignKey("dbo.TB_M_Item", "Supplier_Id", "dbo.TB_M_Supplier", "id", cascadeDelete: true);
        }
    }
}
