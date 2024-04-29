using AutoMapper;
using Common;
using Common.Dto;
using Repository.EFCore;
using Repository.Generic;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RulesRepository : IRulesRepository
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<RuleEngineRule> _ruleUnitOfWork;
        private readonly IUnitOfWork<RuleEngineCategory> _categoryUnitOfWork;

        public RulesRepository(IMapper mapper, IUnitOfWork<RuleEngineRule> ruleUnitOfWork, IUnitOfWork<RuleEngineCategory> categoryUnitOfWork) 
        {
            _mapper = mapper;
            _ruleUnitOfWork = ruleUnitOfWork;
            _categoryUnitOfWork = categoryUnitOfWork;
        }

        public async Task<Response<List<RulesDto>>> GetRules()
        {
            var rules = await _ruleUnitOfWork.Repository.GetAll();
            var categories = await _categoryUnitOfWork.Repository.GetAll();

            var stockAppRules = from rule in rules
                join category in categories on rule.RuleCatId equals category.RuleCatId
                where category.RuleCatAppId == "StockApp"
                select rule;

            var ruleDtos = _mapper.Map<List<RulesDto>>(stockAppRules.ToList());

            return new Response<List<RulesDto>> { Data = ruleDtos };
        }
    }
}
