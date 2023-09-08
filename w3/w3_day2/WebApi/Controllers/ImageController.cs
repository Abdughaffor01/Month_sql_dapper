using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;
    public ImageController(IWebHostEnvironment environment)=>_environment=environment;

    [HttpPost("Upload")]
    public string UPloadImage(IFormFile file) {
        string fullpath = Path.Combine(_environment.WebRootPath, "images",file.FileName);
        using var stream=System.IO.File.Create(fullpath);
        file.CopyTo(stream);
        return fullpath;
    }
}

    