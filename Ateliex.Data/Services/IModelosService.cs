using Ateliex.Models;
using System.Threading.Tasks;

namespace Ateliex.Services
{
    public interface IModelosService
    {
        Task<Modelo> AddAsync(Modelo modelo);

        Task<Recurso> AddRecursoAsync(Recurso recurso);

        Task<Modelo> UpdateAsync(Modelo modelo);

        Task RemoveRecursoAsync(Recurso recurso);

        Task RemoveAsync(Modelo modelo);

        Task<Modelo[]> ObtemModelosAsync();

        Task<Modelo> ObtemModeloAsync(string codigo);

        Task<Modelo[]> ConsultaModelosAsync(ParametrosDeConsultaDeModelos parametros);
    }

    public class ParametrosDeConsultaDeModelos
    {

    }
}
