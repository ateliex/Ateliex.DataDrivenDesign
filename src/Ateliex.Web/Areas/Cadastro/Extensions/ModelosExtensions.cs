using Ateliex.Areas.Cadastro.Models;

namespace Ateliex.Areas.Cadastro.Extensions
{
    public static class ModelosExtensions
    {
        public static bool IsNew(this Modelo modelo)
        {
            return modelo.Codigo == null;
        }
    }
}
