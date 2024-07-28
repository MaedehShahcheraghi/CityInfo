using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.Api.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }


        [HttpGet("{fileid}")]
        public ActionResult GetFile(string fileid)
        {
            string path = "vmess.rar";
            if (! System.IO.File.Exists(path))
            {
               return NotFound();
            }
            var bytes=System.IO.File.ReadAllBytes(path);

            if (! _fileExtensionContentTypeProvider.TryGetContentType(path,out var contenttype))
            {
                contenttype = "Application/octet-stream";
            }

            return File(bytes,contenttype,System.IO.Path.GetFileName(path));
        }
    }
}
