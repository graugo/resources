namespace EFCodeFirst.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EfCodeFistModels", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EfCodeFistModels", "Description");
        }
    }
}
