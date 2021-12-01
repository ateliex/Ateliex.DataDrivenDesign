using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ateliex.Extensions;

public static class DataEntityExtensions
{
    public static bool IsNew(this DataEntity model)
    {
        return model.Id == 0;
    }

    public static string GetTypeName(this DataEntity model)
    {
        var dataEntityType = model.GetType();

        return dataEntityType.Name;
    }

    public static string GetTypeName(this IEnumerable<DataEntity> model)
    {
        var dataEntityType = model.GetType().GetGenericArguments()[0];

        if (dataEntityType == null)
        {
            throw new Exception();
        }

        return dataEntityType.Name;
    }

    public static DataInfoAttribute GetInfo(this DataEntity model)
    {
        var dataEntityType = model.GetType();

        var dataInfoAttributes = dataEntityType.GetCustomAttributes(typeof(DataInfoAttribute), false);

        if (dataInfoAttributes.Length == 0)
        {
            throw new Exception();
        }

        var info = (DataInfoAttribute)dataInfoAttributes[0];

        return info;
    }

    public static DataInfoAttribute GetInfo(this IEnumerable<DataEntity> model)
    {
        var dataEntityType = model.GetType().GetGenericArguments()[0];

        if (dataEntityType == null)
        {
            throw new Exception();
        }

        var dataInfoAttributes = dataEntityType.GetCustomAttributes(typeof(DataInfoAttribute), false);

        if (dataInfoAttributes.Length == 0)
        {
            throw new Exception();
        }

        var info = (DataInfoAttribute)dataInfoAttributes[0];

        return info;
    }
}