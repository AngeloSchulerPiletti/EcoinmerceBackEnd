using Ecoinmerce.Domain.Settings;
using Ecoinmerce.Services.StorageReader.Interfaces;

namespace Ecoinmerce.Services.StorageReader;

public class StorageReader : IStorageReader
{
    private readonly StorageSettings _storageSettings;

    public StorageReader(StorageSettings storageSettings)
    {
        _storageSettings = storageSettings;
    }
}