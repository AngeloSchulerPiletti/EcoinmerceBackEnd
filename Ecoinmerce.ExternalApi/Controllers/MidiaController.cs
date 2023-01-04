using Ecoinmerce.Services.StorageReader.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBitcoin;

namespace Ecoinmerce.ExternalApi.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/midia/")]
[ApiController]
public class MidiaController : ControllerBase
{
    private readonly IStorageReader _storageReader;

    public MidiaController(IStorageReader storageReader)
    {
        _storageReader = storageReader;
    }

    [HttpGet]
    [Route("brand/{filename}")]
    public IActionResult GetMidia(string filename)
    {
        string fullFileName = _storageReader.GetMidiaFileFullName(filename);
        byte[] fileBytes = _storageReader.GetMidiaFile(fullFileName);
        if (fileBytes == null) return NotFound();
        string mediaType = _storageReader.GetImageMediaType(fullFileName);
        return File(fileBytes, mediaType);
    }
}
