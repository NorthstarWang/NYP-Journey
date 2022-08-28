namespace EADPPROJ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tb_CreditRecord");
            AlterColumn("dbo.tb_CreditRecord", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.tb_CreditRecord", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tb_CreditRecord");
            AlterColumn("dbo.tb_CreditRecord", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tb_CreditRecord", "Id");
        }
    }
}
