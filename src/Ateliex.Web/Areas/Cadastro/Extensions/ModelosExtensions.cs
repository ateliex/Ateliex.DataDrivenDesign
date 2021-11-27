using Ateliex.Areas.Cadastro.Models;

namespace Ateliex.Areas.Cadastro.Extensions;

public static class ModelosExtensions
{
    public static bool IsNew(this Modelo modelo)
    {
        return modelo.Codigo == null;
    }

    public static string GetId(this Recurso recurso)
    {
        return $"{recurso.ModeloCodigo},{recurso.Id}";
    }

    public static string GetCodigo(this string id)
    {
        return id.Split(",")[0];
    }

    public static int? GetIdRecurso(this string id)
    {
        return Convert.ToInt32(id.Split(",")[1]);
    }
}