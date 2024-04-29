using System;
using System.Collections.Generic;

namespace Repository.EFCore;

public partial class RuleEngineRule
{
    public int RuleId { get; set; }

    public int? RuleCatId { get; set; }

    public string? RuleName { get; set; }

    public bool? IsActive { get; set; }

    public string? ConditionExpression { get; set; }

    public string? ErrorMessage { get; set; }

    public virtual RuleEngineCategory? RuleCat { get; set; }
}
