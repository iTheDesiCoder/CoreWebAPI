using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class RulesDto
    {
        public int RuleId { get; set; }

        public int RuleCatId { get; set; }

        public string RuleName { get; set; }

        public bool IsActive { get; set; }

        public string ConditionExpression { get; set; }

        public string ErrorMessage { get; set; }
    }
}
