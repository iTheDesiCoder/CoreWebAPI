using System;
using System.Collections.Generic;

namespace Repository.EFCore;

public partial class RuleEngineCategory
{
    public int RuleCatId { get; set; }

    public string? RuleCatAppId { get; set; }

    public string? RuleCatName { get; set; }

    public string? RuleCatDesc { get; set; }

    public virtual ICollection<RuleEngineRule> RuleEngineRules { get; set; } = new List<RuleEngineRule>();
}
