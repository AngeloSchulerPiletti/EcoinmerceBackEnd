
using Ecoinmerce.Utils.FileSystem;
using System.Text.Json;

namespace Ecoinmerce.Utils.Json;

public class JsonModifier<SettingsType>
{
    private readonly string _filePath;
    private readonly string _json;
    public SettingsType ParsedClass;

    public JsonModifier(string filePath)
    {
        _filePath = SymbolicLinkHelpers.IsLink(filePath) ? SymbolicLinkHelpers.GetRealPath(filePath) : filePath;
        _json = File.ReadAllText(_filePath);
        ParsedClass = JsonSerializer.Deserialize<SettingsType>(_json);
    }

    public (bool result, Exception exception) SaveDeserializedJson(bool format = true)
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(_filePath, JsonSerializer.Serialize(ParsedClass, format ? options : null));

            return (true, null);
        }
        catch (Exception exception)
        {
            return (false, exception);
        }
    }
}
