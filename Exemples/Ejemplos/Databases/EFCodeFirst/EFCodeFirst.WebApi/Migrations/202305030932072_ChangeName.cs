namespace EFCodeFirst.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EfCodeFistModels", "Name", c => c.String(maxLength: 25, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EfCodeFistModels", "Name", c => c.String());
        }
    }
}
