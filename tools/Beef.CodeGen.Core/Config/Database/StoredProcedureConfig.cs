﻿// Copyright (c) Avanade. Licensed under the MIT License. See https://github.com/Avanade/Beef

using Beef.CodeGen.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Beef.CodeGen.Config.Database
{
    /// <summary>
    /// Represents the stored procedure configuration.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [ClassSchema("StoredProcedure", Title = "The **StoredProcedure** is used to identify a database `Stored Procedure` and define its code-generation characteristics.", Description = "", Markdown = "")]
    [CategorySchema("Key", Title = "Provides the **key** configuration.")]
    [CategorySchema("Auth", Title = "Provides the **Authorization** configuration.")]
    public class StoredProcedureConfig : ConfigBase<CodeGenConfig, TableConfig>
    {
        #region Key

        /// <summary>
        /// Gets or sets the name of the `StoredProcedure` in the database.
        /// </summary>
        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Key", Title = "The name of the `StoredProcedure` in the database.", IsMandatory = true, IsImportant = true)]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the stored procedure operation type.
        /// </summary>
        [JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Key", Title = "The stored procedure operation type.", IsImportant = true,
            Options = new string[] { "Get", "GetColl", "Create", "Update", "Upsert", "Delete", "Merge" },
            Description = "Defaults to `GetColl`.")]
        public string? Type { get; set; }

        /// <summary>
        /// Indicates whether standardized paging support should be added.
        /// </summary>
        [JsonProperty("paging", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Key", Title = "Indicates whether standardized paging support should be added.", IsImportant = true,
            Description = "This only applies where the stored procedure operation `Type` is `GetColl`.")]
        public bool? Paging { get; set; }

        /// <summary>
        /// Gets or sets the SQL statement to perform the reselect after a `Create`, `Update` or `Upsert` stored procedure operation `Type`.
        /// </summary>
        [JsonProperty("reselectStatement", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Key", Title = "The SQL statement to perform the reselect after a `Create`, `Update` or `Upsert` stored procedure operation `Type`.",
            Description = "Defaults to `[{{Table.Schema}}].[sp{{Table.Name}}Get]` passing the primary key column(s).")]
        public string? ReselectStatement { get; set; }

        /// <summary>
        /// Indicates whether to select into a `#TempTable` to allow other statements to get access to the selected data. 
        /// </summary>
        [JsonProperty("intoTempTable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Key", Title = "Indicates whether to select into a `#TempTable` to allow other statements to get access to the selected data.",
            Description = "A `Select * from #TempTable` is also performed (code-generated) where the stored procedure operation `Type` is `GetColl`.")]
        public bool? IntoTempTable { get; set; }

        /// <summary>
        /// Gets or sets the column names (comma separated) to be used in the `Merge` statement to determine whether to insert, update or delete.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "DTO.")]
        [JsonProperty("mergeOverrideIdentityColumns", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Key", Title = "The column names to be used in the `Merge` statement to determine whether to insert, update or delete.",
            Description = "This is used to override the default behaviour of using the identity column(s).")]
        public List<string>? MergeOverrideIdentityColumns { get; set; }

        /// <summary>
        /// Gets or sets the table hints using the SQL Server `WITH()` statement; the value specified will be used as-is; e.g. `NOLOCK` will result in `WITH(NOLOCK)`.
        /// </summary>
        [JsonProperty("withHints", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Key", Title = "the table hints using the SQL Server `WITH()` statement; the value specified will be used as-is; e.g. `NOLOCK` will result in `WITH(NOLOCK)`.")]
        public string? WithHints { get; set; }

        /// <summary>
        /// Gets or sets the permission (full name being `name.action`) override to be used for security permission checking.
        /// </summary>
        [JsonProperty("permission", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Auth", Title = "The name of the `StoredProcedure` in the database.")]
        public string? Permission { get; set; }

        #endregion

        /// <summary>
        /// Gets or sets the corresponding <see cref="ParameterConfig"/> collection.
        /// </summary>
        [JsonProperty("parameters", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertyCollectionSchema(Title = "The corresponding `Parameter` collection.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "This is appropriate for what is obstensibly a DTO.")]
        public List<ParameterConfig>? Parameters { get; set; }

        /// <summary>
        /// Gets or sets the corresponding <see cref="WhereConfig"/> collection.
        /// </summary>
        [JsonProperty("where", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertyCollectionSchema(Title = "The corresponding `Where` collection.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "This is appropriate for what is obstensibly a DTO.")]
        public List<WhereConfig>? Where { get; set; }

        /// <summary>
        /// Gets or sets the corresponding <see cref="OrderByConfig"/> collection.
        /// </summary>
        [JsonProperty("orderby", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertyCollectionSchema(Title = "The corresponding `OrderBy` collection.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "This is appropriate for what is obstensibly a DTO.")]
        public List<OrderByConfig>? OrderBy { get; set; }

        /// <summary>
        /// Gets or sets the corresponding <see cref="ExecuteConfig"/> collection.
        /// </summary>
        [JsonProperty("execute", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertyCollectionSchema(Title = "The corresponding `Execute` collection.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "This is appropriate for what is obstensibly a DTO.")]
        public List<ExecuteConfig>? Execute { get; set; }

        /// <summary>
        /// Gets the parameters to be used as the arguments parameters.
        /// </summary>
        public List<ParameterConfig> ArgumentParameters => Parameters!.Where(x => !x.WhereOnly).ToList();

        /// <summary>
        /// Gets the parameters defined as a collection.
        /// </summary>
        public List<ParameterConfig> CollectionParameters => Parameters!.Where(x => CompareValue(x.Collection, true)).ToList();

        /// <summary>
        /// Gets the "Before" <see cref="ExecuteConfig"/> collection.
        /// </summary>
        public List<ExecuteConfig>? ExecuteBefore => Execute!.Where(x => x.Location == "Before").ToList();

        /// <summary>
        /// Gets the "After" <see cref="ExecuteConfig"/> collection.
        /// </summary>
        public List<ExecuteConfig>? ExecuteAfter => Execute!.Where(x => x.Location == "After").ToList();

        /// <summary>
        /// Gets the settable columns.
        /// </summary>
        public List<Column> SettableColumns { get; } = new List<Column>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "Requirement is for lowercase.")]
        protected override void Prepare()
        {
            Type = DefaultWhereNull(Type, () => "GetColl");
            Permission = DefaultWhereNull(Permission?.ToUpperInvariant(), () => Parent!.Permission == null ? null : Parent!.Permission!.ToUpperInvariant() + "." + Type switch
            {
                "Delete" => "DELETE",
                "Get" => "READ",
                "GetColl" => "READ",
                _ => "WRITE"
            });

            if (Parameters == null)
                Parameters = new List<ParameterConfig>();

            if (Where == null)
                Where = new List<WhereConfig>();

            if (OrderBy == null)
                OrderBy = new List<OrderByConfig>();

            if (Execute == null)
                Execute = new List<ExecuteConfig>();

            AddColumnsAsParameters();

            foreach (var parameter in Parameters.AsQueryable().Reverse())
            {
                parameter.Prepare(Root!, this);
                Where.Insert(0, new WhereConfig { Statement = parameter.WhereSql });
            }

            foreach (var where in Where)
            {
                where.Prepare(Root!, this);
            }

            foreach (var orderby in OrderBy)
            {
                orderby.Prepare(Root!, this);
            }

            foreach (var execute in Execute)
            {
                execute.Prepare(Root!, this);
            }
        }

        /// <summary>
        /// Insert the special TenantId and IsDeleted where only parameters (i.e. not used as arguments).
        /// </summary>
        private void AddWhereOnlyParameters(bool bookEnd)
        {
            if (Parent!.DbTable!.IsAView)
                return;

            var tenantId = Parent.ColumnTenantId == null ? null : new ParameterConfig { Name = Parent.ColumnTenantId.Name, WhereOnly = true };
            var isDeleted = Parent.ColumnIsDeleted == null ? null : new ParameterConfig { Name = Parent.ColumnIsDeleted.Name, WhereOnly = true, WhereSql = $"ISNULL({Parent.ColumnIsDeleted.QualifiedName}, 0) = 0" };

            if (bookEnd)
            {
                if (tenantId != null)
                    Parameters!.Insert(0, tenantId);

                if (isDeleted != null)
                    Parameters!.Add(isDeleted);
            }
            else
            {
                if (tenantId != null)
                    Parameters!.Add(tenantId);

                if (isDeleted != null)
                    Parameters!.Add(isDeleted);
            }
        }

        /// <summary>
        /// Add columns as parameters depending on type.
        /// </summary>
        private void AddColumnsAsParameters()
        {
            switch (Type)
            {
                case "Get":
                    foreach (var c in Parent!.PrimaryKeyColumns.AsEnumerable().Reverse())
                    {
                        Parameters!.Insert(0, new ParameterConfig { Name = c.Name, Nullable = c.DbColumn!.IsNullable });
                    }

                    AddWhereOnlyParameters(bookEnd: false);
                    break;

                case "GetColl":
                    AddWhereOnlyParameters(bookEnd: true);
                    break;

                case "Create":
                    // Ignore no-go columns (not a parameter or settable column).
                    foreach (var c in Parent!.Columns.Where(x => !(x == Parent.ColumnIsDeleted || x == Parent.ColumnRowVersion || x == Parent.ColumnUpdatedBy || x == Parent.ColumnUpdatedDate || x.DbColumn!.IsComputed)).Reverse())
                    {
                        if (c != Parent.ColumnTenantId)
                        {
                            var audit = c == Parent.ColumnCreatedBy || c == Parent.ColumnCreatedDate;
                            if (c.DbColumn!.IsPrimaryKey)
                                Parameters!.Insert(0, new ParameterConfig { Name = c.Name, Nullable = c.DbColumn!.IsIdentity ? false : c.DbColumn.IsNullable, Output = c.DbColumn.IsIdentity });
                            else
                                Parameters!.Insert(0, new ParameterConfig { Name = c.Name, Nullable = audit ? true : c.DbColumn.IsNullable });
                        }

                        if (!c.DbColumn!.IsPrimaryKey && !c.DbColumn.IsIdentity)
                            SettableColumns.Insert(0, c.DbColumn);
                    }

                    break;
            }
        }
    }
}