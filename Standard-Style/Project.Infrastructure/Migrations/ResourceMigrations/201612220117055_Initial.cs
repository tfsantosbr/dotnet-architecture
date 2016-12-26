namespace Project.Infrastructure.Migrations.ResourceMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("Core.Client");
            DropPrimaryKey("Core.RefreshToken");
            AlterColumn("Core.Client", "Id", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("Core.RefreshToken", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("Core.Client", "Id");
            AddPrimaryKey("Core.RefreshToken", new[] { "Id", "Browser" });
            CreateIndex("Core.Client", "Id", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("Core.Client", new[] { "Id" });
            DropPrimaryKey("Core.RefreshToken");
            DropPrimaryKey("Core.Client");
            AlterColumn("Core.RefreshToken", "Id", c => c.Guid(nullable: false));
            AlterColumn("Core.Client", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("Core.RefreshToken", new[] { "Id", "Browser" });
            AddPrimaryKey("Core.Client", "Id");
        }
    }
}
