namespace Project.Infrastructure.Migrations
{
    using Project.Infrastructure.Context;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<InfraContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(InfraContext context)
        {
        }
    }
}
