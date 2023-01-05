

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ecoinmerce.Utils.Json;

public static class JsonFormatter
{
    public static string FormatJsonToInline(string formattedJson)
    {
        //JValue.Parse(formattedJson).ToString(Formatting.Indented);
        return formattedJson.Replace("\r\n", "");
    }
}
