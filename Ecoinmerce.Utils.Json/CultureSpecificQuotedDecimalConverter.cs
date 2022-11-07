using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Ecoinmerce.Utils.Json;

public class CultureSpecificQuotedDecimalConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            return Convert.ToDecimal(reader.GetString(), System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
        }
        else
        {
            return reader.GetInt32();
        }
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        Write(writer, value, options);
    }
}
