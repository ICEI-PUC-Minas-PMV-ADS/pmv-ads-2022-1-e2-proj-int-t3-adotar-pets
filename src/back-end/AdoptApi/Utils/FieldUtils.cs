namespace AdoptApi.Utils;

public static class FieldUtils
{
    public static T? UpdateFieldOrUseDefault<T>(T value, T? defaultValue)
    {
        return EqualityComparer<T>.Default.Equals(value, default) ? defaultValue : value;
    }
}