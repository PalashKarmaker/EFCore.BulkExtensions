﻿using EFCore.Bulk.SqlAdapters;
using Xunit;

namespace EFCore.Bulk.Tests.BatchUtil;

public class BatchUtilTests
{
    [Fact]
    public void GetBatchSql_UpdateSqlite_ReturnsExpectedValues()
    {
        ContextUtil.DatabaseType = SqlType.Sqlite;

        using var context = new TestContext(ContextUtil.GetOptions());
        (string sql, string tableAlias, string tableAliasSufixAs, _, _, _) = Bulk.BatchUtil.GetBatchSql(context.Items, context, true);

        Assert.Equal("\"Item\"", tableAlias);
        Assert.Equal(" AS \"i\"", tableAliasSufixAs);
    }
}
