using Ecoinmerce.Domain.Settings;
using System.Text;

namespace Ecoinmerce.Services.StorageReader.Interfaces;

public interface IStorageReader
{
    public string GetImageMediaType(string fileFullPathName);
    public string GetMidiaFileFullName(string fileName);
    public byte[] GetMidiaFile(string fullFileName);
}
