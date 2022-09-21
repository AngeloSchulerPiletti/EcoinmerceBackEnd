using Microsoft.AspNetCore.Mvc;

namespace Ecoinmerce.ExternalApi.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/plugin/")]
[ApiController]
public class PluginController : ControllerBase
{
    private readonly string _absoluteBasePath;
    public PluginController()
    {
        var relativePath = ".\\PartnerPlugin\\Scripts\\";
        _absoluteBasePath = Path.GetFullPath(relativePath);
    }

    private string ReadPluginFileFromFileName(string fileName)
    {
        return System.IO.File.ReadAllText(Path.Combine(_absoluteBasePath, fileName));
    }

    private class JavaScripResult : ContentResult
    {
        public JavaScripResult(string script)
        {
            StatusCode = 200;
            Content = script;
            ContentType = "text/javascript";
        }
    }

    [HttpGet]
    [Route("easy-plugin")]
    public ContentResult GetEasyPlugin()
    {
        string javascript = ReadPluginFileFromFileName("easy-plugin.js");

        return new JavaScripResult(javascript);
    }
}
