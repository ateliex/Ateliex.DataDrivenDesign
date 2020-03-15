using Ateliex.Models;
using System.Threading.Tasks;

namespace Ateliex.Services
{
    public interface IModelosService
    {
        Task<Modelo> AddAsync(Modelo modelo);

        Task<Recurso> AddRecursoAsync(Recurso recurso);

        Task RemoveRecursoAsync(string codigo, string descricao);

        Task RemoveAsync(string codigo);

        Task<Modelo[]> ObtemModelosAsync();

        Task<Modelo[]> ConsultaModelosAsync(ParametrosDeConsultaDeModelos parametros);
    }

    public class ParametrosDeConsultaDeModelos
    {

    }
}
