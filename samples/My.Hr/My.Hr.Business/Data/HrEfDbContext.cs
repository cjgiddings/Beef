﻿using Beef;
using Beef.Data.Database;
using Beef.Data.EntityFrameworkCore;
using My.Hr.Business.Data.EfModel;
using Microsoft.EntityFrameworkCore;

namespace My.Hr.Business.Data
{
    /// <summary>
    /// Represents the Entity Framework <see cref="DbContext"/>.
    /// </summary>
    public class HrEfDbContext : DbContext, IEfDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HrEfDbContext"/> class.
        /// </summary>
        /// <param name="options">The <see cref="DbContextOptions{HrEfDbContext}"/>.</param>
        /// <param name="db">The base <see cref="IDatabase"/>.</param>
        public HrEfDbContext(DbContextOptions<HrEfDbContext> options, IDatabase db) : base(options) => BaseDatabase = Check.NotNull(db, nameof(db));

        /// <summary>
        /// Gets the base <see cref="IDatabase"/>.
        /// </summary>
        public IDatabase BaseDatabase { get; }

        /// <summary>
        /// Overrides the <see cref="DbContext.OnConfiguring(DbContextOptionsBuilder)"/> to leverage the <see cref="My.Hr.Business.Data.Database"/> connection management.
        /// </summary>
        /// <param name="optionsBuilder">The <see cref="DbContextOptionsBuilder"/>.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Uses the DB connection management from the database class - ensures DB connection pooling and required DB session context setting.
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(BaseDatabase.GetConnection());
        }

        /// <summary>
        /// Overrides the <see cref="DbContext.OnModelCreating(ModelBuilder)"/>.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add the generated models to the model builder.
            modelBuilder.AddGeneratedModels();
        }
    }
}