using Ecoinmerce.Domain.Settings;
using Ecoinmerce.Services.StorageReader.Interfaces;
using System.Text;

namespace Ecoinmerce.Services.StorageReader;

public class StorageReader : IStorageReader
{
    private readonly StorageSettings _storageSettings;
    private readonly string _baseDir;
    private readonly string _diskRoot;

    public StorageReader(StorageSettings storageSettings)
    {
        _storageSettings = storageSettings;

        string runningDirectory = Environment.CurrentDirectory;
        _diskRoot = Path.GetPathRoot(runningDirectory);
        _baseDir = Path.Combine(_diskRoot, _storageSettings.RootFolder);
    }


    public string GetImageMediaType(string fileFullPathName)
    {
        FileInfo fileInfo = new(fileFullPathName);

        StringBuilder stringBuilderMediaType = new();
        stringBuilderMediaType.Append("image/");
        stringBuilderMediaType.Append(fileInfo.Extension[1..]);
        return stringBuilderMediaType.ToString();
    }

    public string GetMidiaFileFullName(string fileName)
    {
        return Path.Combine(_baseDir, _storageSettings.MidiaFolder, fileName);
    }

    public byte[] GetMidiaFile(string fullFileName)
    {
        try
        {
            return File.ReadAllBytes(fullFileName);
        }
        catch (Exception)
        {
            return null;
        }
    }
}