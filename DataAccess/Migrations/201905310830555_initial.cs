namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_M_Item", "Supplier_Id", "dbo.TB_M_Supplier");
            DropIndex("dbo.TB_M_Item", new[] { "Supplier_Id" });
            AddColumn("dbo.TB_M_Item", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.TB_M_Supplier", "IsDelete", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TB_M_Item", "Supplier_Id", c => c.Int());
            CreateIndex("dbo.TB_M_Item", "Supplier_Id");
            AddForeignKey("dbo.TB_M_Item", "Supplier_Id", "dbo.TB_M_Supplier", "Id");
            DropColumn("dbo.TB_M_Item", "IsDalete");
            DropColumn("dbo.TB_M_Supplier", "IsDalete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_M_Supplier", "IsDalete", c => c.Boolean(nullable: false));
            AddColumn("dbo.TB_M_Item", "IsDalete", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.TB_M_Item", "Supplier_Id", "dbo.TB_M_Supplier");
            DropIndex("dbo.TB_M_Item", new[] { "Supplier_Id" });
            AlterColumn("dbo.TB_M_Item", "Supplier_Id", c => c.Int(nullable: false));
            DropColumn("dbo.TB_M_Supplier", "IsDelete");
            DropColumn("dbo.TB_M_Item", "IsDelete");
            CreateIndex("dbo.TB_M_Item", "Supplier_Id");
            AddForeignKey("dbo.TB_M_Item", "Supplier_Id", "dbo.TB_M_Supplier", "Id", cascadeDelete: true);
        }
    }
}
