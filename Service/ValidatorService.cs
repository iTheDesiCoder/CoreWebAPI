using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service.Interface;
using System.Linq.Expressions;
using System.Reflection;
using Common;
using Repository.Interface;
using Common.Dto;
using System.Data;
using RulesEngine.Models;
using Rule = RulesEngine.Models.Rule;

namespace Service
{
    public class ValidatorService<T> : IValidatorService<T> where T : class
    {


        private readonly IRulesRepository _rulesRepository;

        public ValidatorService(IRulesRepository rulesRepository)
        {
            _rulesRepository = rulesRepository;
        }
        public async Task<List<RulesDto>> Validate(T entity)
        {
           

            var rulesDtoList = (await _rulesRepository.GetRules()).Data;
            var failedRules = new List<RulesDto>();
            List<Rule> rules = new List<RulesEngine.Models.Rule>();
            foreach (var ruledto in rulesDtoList)
            {
                RulesEngine.Models.Rule rule = new Rule();
                rule.RuleName = ruledto.RuleName;
                rule.Expression = ruledto.ConditionExpression;
                rule.ErrorMessage = ruledto.ErrorMessage;
                rule.RuleExpressionType = RuleExpressionType.LambdaExpression;
                rules.Add(rule);
            }
            Workflow wf = new Workflow();
            wf.WorkflowName = entity.GetType().Name;
            wf.Rules = rules;

            var workflows = new List<Workflow>();
            workflows.Add(wf);
            var ruleEngine = new RulesEngine.RulesEngine(workflows.ToArray());

            var ruleParameter = new RuleParameter(entity.GetType().Name,entity);
            var resultList = await ruleEngine.ExecuteAllRulesAsync(entity.GetType().Name, ruleParameter);

            foreach (var result in resultList)
            {
                if (!result.IsSuccess)
                {
                    failedRules.Add( new RulesDto
                    {
                        RuleName = result.Rule.RuleName,
                        ErrorMessage = result.Rule.ErrorMessage
                    });
                }
            }
            return failedRules;
        }

        
    }
}
