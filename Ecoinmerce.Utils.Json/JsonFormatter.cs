namespace Ecoinmerce.Utils.Json;

public static class JsonFormatter
{
    public static string FormatJsonToInline(string formattedJson)
    {
        return formattedJson.Replace("\r\n", "");
    }
}
