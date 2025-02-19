﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.Common;

namespace EFCore.Bulk.SqlAdapters.SqlServer;

/// <inheritdoc/>
public class SqlServerDbServer : IDbServer
{
    SqlType IDbServer.Type => SqlType.SqlServer;

    SqlServerAdapter _adapter = new();
    ISqlOperationsAdapter IDbServer.Adapter => _adapter;

    SqlServerDialect _dialect = new();
    IQueryBuilderSpecialization IDbServer.Dialect => _dialect;

    /// <inheritdoc/>
    public DbConnection? DbConnection { get; set; }

    /// <inheritdoc/>
    public DbTransaction? DbTransaction { get; set; }

    SqlAdapters.SqlQueryBuilder _queryBuilder = new SqlServerQueryBuilder();
    /// <inheritdoc/>
    public SqlQueryBuilder QueryBuilder => _queryBuilder;

    string IDbServer.ValueGenerationStrategy => nameof(SqlServerValueGenerationStrategy);

    bool IDbServer.PropertyHasIdentity(IAnnotation annotation) => (SqlServerValueGenerationStrategy?)annotation.Value == SqlServerValueGenerationStrategy.IdentityColumn;
}
