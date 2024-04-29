using Common;
using Common.Dto;
using Repository.EFCore;
using Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRulesRepository 
    {
        Task<Response<List<RulesDto>>> GetRules();
    }
}
