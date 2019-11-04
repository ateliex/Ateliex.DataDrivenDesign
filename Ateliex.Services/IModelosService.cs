using Ateliex.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ateliex.Services
{
    public interface IModelosService
    {
        Task<Modelo> CadastraModeloAsync(Modelo modelo);

        Task<Recurso> AdicionaRecursoDeModeloAsync(Recurso recurso);

        Task RemoveRecursoDeModeloAsync(string codigo, string descricao);

        Task RemoveModeloAsync(string codigo);

        Task<Modelo[]> ObtemModelosAsync();

        Task<Modelo[]> ConsultaModelosAsync(ParametrosDeConsultaDeModelos parametros);
    }

    public class ParametrosDeConsultaDeModelos
    {

    }
}
