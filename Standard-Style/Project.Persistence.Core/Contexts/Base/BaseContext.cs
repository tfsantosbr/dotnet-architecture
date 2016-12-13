﻿using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Project.Configurations;

namespace Project.Persistence.Core.Contexts.Base
{
    /// <summary>
    ///     BASE CONTEXT
    /// </summary>
    /// <typeparam name="TContext">DbContext Type</typeparam>
    public abstract class BaseContext<TContext> : DbContext
        where TContext : DbContext
    {
        #region - MAIN METHODS -

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }

        #endregion

        #region - CONSTRUCTORS -

        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }

        protected BaseContext()
            : base(ConnectionStrings.ResourceConnection)
        {
        }

        #endregion
    }
}