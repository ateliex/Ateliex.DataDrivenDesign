using Ateliex.Models;
using System.Threading.Tasks;

namespace Ateliex.Services
{
    public interface IPlanosComerciaisService
    {
        Task<PlanoComercial> ObtemPlanoComercialAsync(string id);

        Task AddAsync(PlanoComercial planoComercial);

        Task UpdateAsync(PlanoComercial planoComercial);

        Task RemoveAsync(PlanoComercial planoComercial);
    }

}
