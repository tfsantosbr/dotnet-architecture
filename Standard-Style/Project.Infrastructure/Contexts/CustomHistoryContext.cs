using Project.Configurations;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;

namespace Project.Infrastructure.Contexts
{
    public class CustomHistoryContext : HistoryContext
    {
        public CustomHistoryContext(DbConnection dbConnection, String defaultSchema)
            : base(dbConnection, defaultSchema)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HistoryRow>().ToTable("MigrationHistory", DefaultSchemas.Admin);
            modelBuilder.Entity<HistoryRow>().Property(p => p.MigrationId).HasColumnName("MigrationId");
        }
    }

    public class ModelConfiguration : DbConfiguration
    {
        public ModelConfiguration()
        {
            this.SetHistoryContext("System.Data.SqlClient",
                (connection, defaultSchema) => new CustomHistoryContext(connection, defaultSchema));
        }
    }
}
