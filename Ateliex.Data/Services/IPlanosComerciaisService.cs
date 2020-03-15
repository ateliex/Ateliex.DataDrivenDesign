using Ateliex.Models;
using System.Threading.Tasks;

namespace Ateliex.Services
{
    public interface IPlanosComerciaisService
    {
        Task<PlanoComercial> ObtemPlanoComercial(string id);

        Task Add(PlanoComercial planoComercial);

        Task Update(PlanoComercial planoComercial);

        Task Remove(PlanoComercial planoComercial);
    }

}
