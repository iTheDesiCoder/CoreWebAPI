using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IValidatorService<T> where T : class
    {
        Task<List<RulesDto>> Validate(T obj);
    }
}
