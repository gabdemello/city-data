using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityDataAPI.Controllers
{
    [Route("api/files")]
    [ApiController]
    [Authorize]
    public class FilesController : ControllerBase
    {
        public readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
        
        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
                ?? throw new System.ArgumentException(
                    nameof(fileExtensionContentTypeProvider));    
        }

        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            var pathToFile = "Draft.pdf";

            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            if(!_fileExtensionContentTypeProvider.TryGetContentType(
                pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);

            return File(bytes, contentType, Path.GetFileName(pathToFile)); 

        }
    }
}
