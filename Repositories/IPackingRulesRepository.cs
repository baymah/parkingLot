using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repository{
    public interface IPackingRulesRepository
    {
        Task CreatePackingRulesAsync(PackingRules packingRules);
        Task<PackingRules> GetPackingRuleByNameAsync(string packingRulesName);
    }
}