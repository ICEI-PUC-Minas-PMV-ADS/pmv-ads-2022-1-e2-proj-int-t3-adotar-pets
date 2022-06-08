namespace AdoptApi.Utils;

public static class FieldUtils
{
    public static string ChangeIfEmptyField(string selectedField, string dbField)
    {
        if (String.IsNullOrEmpty(selectedField))
        {
            return dbField;
        }
        return selectedField;
    }
}