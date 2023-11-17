﻿using System.Collections.Generic;

namespace EFCore.Bulk.Tests.IncludeGraph.Model;

public class WorkOrder
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;

    public Asset Asset { get; set; } = null!;
    public ICollection<WorkOrderSpare> WorkOrderSpares { get; set; } = new HashSet<WorkOrderSpare>();
}
