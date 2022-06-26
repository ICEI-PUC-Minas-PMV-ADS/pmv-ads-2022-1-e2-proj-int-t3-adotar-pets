using Microsoft.Extensions.FileSystemGlobbing.Internal;

namespace AdoptApi.Utils;

public static class FieldUtils
{
    public static T? UpdateFieldOrUseDefault<T>(T value, T? defaultValue)
    {
        return EqualityComparer<T>.Default.Equals(value, defaultValue) ? defaultValue : value;
    }

    public static bool VariableIsNull<T>(T value)
    {
        return value == null;
    }
}