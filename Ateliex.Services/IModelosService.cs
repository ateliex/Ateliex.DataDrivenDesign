using Ateliex.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ateliex.Services
{
    public interface IModelosService
    {
        Modelo[] ConsultaModelos(ParametrosDeConsultaDeModelos parametros);

        Modelo CadastraModelo(Modelo modelo);

        Recurso AdicionaRecursoDeModelo(Recurso recurso);

        void RemoveRecursoDeModelo(string codigo, string descricao);

        void RemoveModelo(string codigo);
    }

    public class ParametrosDeConsultaDeModelos
    {

    }
}
