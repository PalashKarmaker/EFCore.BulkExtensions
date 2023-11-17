﻿using System.Diagnostics;
using System.Globalization;

namespace EFCore.Bulk;

/// <summary>
/// Contains activity sources
/// </summary>
public static class ActivitySources
{
    private static readonly ActivitySource ActivitySource = new("EFCore.Bulk");

    /// <summary>
    /// Starts the activity
    /// </summary>
    /// <param name="operationType"></param>
    /// <param name="entitiesCount"></param>
    /// <returns></returns>
    public static Activity? StartExecuteActivity(OperationType operationType, int entitiesCount)
    {
        var activity = ActivitySource.StartActivity("EFCore.Bulk.BulkExecute");
        if (activity != null)
        {
            activity.AddTag("operationType", operationType.ToString("G"));
            activity.AddTag("entitiesCount", entitiesCount.ToString(CultureInfo.InvariantCulture));
        }

        return activity;
    }
}
