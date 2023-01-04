using Ecoinmerce.SmartContracts.Interfaces;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Ecoinmerce.SmartContracts;

public class BinReader : IBinReader
{
    private readonly string _smartContractName;
    private readonly string _baseDir;
    public BinReader()
    {
        string runningDirectory = Environment.CurrentDirectory;
        string solutionDirectory = Directory.GetParent(runningDirectory).FullName;
        _baseDir = Path.Combine(solutionDirectory, "Ecoinmerce.SmartContracts");

        string[] fullFileNames = Directory.GetFiles(Path.Combine(_baseDir, "SmartContracts"), "*.sol").ToArray();

        _smartContractName = null;
        for (int i = 0; i < fullFileNames.Length; i++)
        {
            string fileName = Path.GetFileNameWithoutExtension(fullFileNames[i]);
            if (fileName[0] != 'I')
            {
                _smartContractName = fileName;
                break;
            }

        }

        if (_smartContractName == null)
            throw new Exception("SmartContract não encontrado, ou mais de um encontrado");
    }

    public string GetSmartContractJson()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.Append(_baseDir);
        stringBuilder.Append("/SmartContracts/bin/");
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
