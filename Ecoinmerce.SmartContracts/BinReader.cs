using Ecoinmerce.SmartContracts.Interfaces;
using System.Text;

namespace Ecoinmerce.SmartContracts;

public class BinReader : IBinReader
{
    private readonly string _smartContractName;
    public BinReader()
    {
        string[] fileNames = Directory.GetFiles("SmartContracts", @"\^[^I].+$\");
        if (fileNames.Length == 0)
            throw new Exception("SmartContract não encontrado");
        _smartContractName = fileNames[0];
    }

    public string GetSmartContractJson()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.Append("SmartContracts/");
        stringBuilder.Append(_smartContractName);
        stringBuilder.Append(".json");

        string smartContractJson;

        try
        {
            smartContractJson = File.ReadAllText(stringBuilder.ToString());
        }
        catch (Exception)
        {
            return null;
        }
        return smartContractJson;
    }
}
