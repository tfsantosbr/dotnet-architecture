using Project.Infrastructure.Context;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;

namespace Project.TestingProject.Base
{
    public class DatabaseSetup
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public void WipeAndCreateDatabase()
        {
            // drop database first
            ReallyDropDatabase(connectionString);

            // Now time to create the database from migrations
            // MyApp.Data.Migrations.Configuration is migration configuration class 
            // this class is crated for you automatically when you enable migrations
            var initializer = new MigrateDatabaseToLatestVersion<InfraContext, Project.Infrastructure.Migrations.Configuration>();

            // set DB initializer to execute migrations
            Database.SetInitializer(initializer);

            // now actually force the initialization to happen
            using (var context = new InfraContext(connectionString))
            {
                Console.WriteLine("Starting creating database");
                context.Database.Initialize(true);
                Console.WriteLine("Database is created");
            }

            // And after the DB is created, you can put some initial base data 
            // for your tests to use
            // usually this data represents lookup tables, like Currencies, Countries, Units of Measure, etc
            using (var domainContext = new InfraContext(connectionString))
            {
                Console.WriteLine("Seeding test data into database");
                // discussion for that to follow
                //SeedContextForTests.Seed(domainContext);
                Console.WriteLine("Seeding test data is complete");
            }
        }

        public void UpdateDatabase()
        {
            var migrationConfiguration = new Project.Infrastructure.Migrations.Configuration()
            {
                TargetDatabase = new DbConnectionInfo(connectionString, "System.Data.SqlClient")
            };

            var migrator = new DbMigrator(migrationConfiguration);
            migrator.Update();
        }

        private static void ReallyDropDatabase(String connectionString)
        {
            const string DropDatabaseSql =
            "if (select DB_ID('{0}')) is not null\r\n"
            + "begin\r\n"
            + "alter database [{0}] set offline with rollback immediate;\r\n"
            + "alter database [{0}] set online;\r\n"
            + "drop database [{0}];\r\n"
            + "end";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var sqlToExecute = String.Format(DropDatabaseSql, connection.Database);

                    var command = new SqlCommand(sqlToExecute, connection);

                    Console.WriteLine("Dropping database");
                    command.ExecuteNonQuery();
                    Console.WriteLine("Database is dropped");
                }
            }
            catch (SqlException sqlException)
            {
                if (sqlException.Message.StartsWith("Cannot open database"))
                {
                    Console.WriteLine("Database does not exist.");
                    return;
                }
                throw;
            }
        }
    }
}
