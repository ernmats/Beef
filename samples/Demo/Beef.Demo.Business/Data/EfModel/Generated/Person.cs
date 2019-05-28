/*
 * This file is automatically generated; any changes will be lost. 
 */

using System;
using Microsoft.EntityFrameworkCore;

namespace Beef.Demo.Business.Data.EfModel
{
    /// <summary>
    /// Represents the Entity Framework (EF) model for database object 'Demo.Person'.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the 'PersonId' column value.
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// Gets or sets the 'FirstName' column value.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the 'LastName' column value.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the 'Birthday' column value.
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Gets or sets the 'GenderId' column value.
        /// </summary>
        public Guid? GenderId { get; set; }

        /// <summary>
        /// Gets or sets the 'Street' column value.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the 'City' column value.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the 'RowVersion' column value.
        /// </summary>
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Gets or sets the 'CreatedBy' column value.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the 'CreatedDate' column value.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the 'UpdatedBy' column value.
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the 'UpdatedDate' column value.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the 'UniqueCode' column value.
        /// </summary>
        public string UniqueCode { get; set; }

        /// <summary>
        /// Gets or sets the 'EyeColorCode' column value.
        /// </summary>
        public string EyeColorCode { get; set; }

        /// <summary>
        /// Adds the table/model configuration to the <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/>.</param>
        public static void AddToModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", "Demo");
                entity.HasKey("PersonId");
                entity.Property("PersonId").HasColumnType("UNIQUEIDENTIFIER");
                entity.Property("FirstName").HasColumnType("NVARCHAR(50)");
                entity.Property("LastName").HasColumnType("NVARCHAR(50)");
                entity.Property("Birthday").HasColumnType("DATE");
                entity.Property("GenderId").HasColumnType("UNIQUEIDENTIFIER");
                entity.Property("Street").HasColumnType("NVARCHAR(100)");
                entity.Property("City").HasColumnType("NVARCHAR(100)");
                entity.Property("RowVersion").HasColumnType("TIMESTAMP").IsRowVersion();
                entity.Property("CreatedBy").HasColumnType("NVARCHAR(250)").ValueGeneratedOnUpdate();
                entity.Property("CreatedDate").HasColumnType("DATETIME2").ValueGeneratedOnUpdate();
                entity.Property("UpdatedBy").HasColumnType("NVARCHAR(250)").ValueGeneratedOnAdd();
                entity.Property("UpdatedDate").HasColumnType("DATETIME2").ValueGeneratedOnAdd();
                entity.Property("UniqueCode").HasColumnType("NVARCHAR(20)");
                entity.Property("EyeColorCode").HasColumnType("NVARCHAR(50)");
            });
        }
    }
}