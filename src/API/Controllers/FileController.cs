using Microsoft.AspNetCore.Mvc;
using OI.Template.Application.File.Commands.FileUpload;
using OI.Template.Contract;

namespace OI.Template.API.Controllers;

public class FileController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UploadFile([FromForm] FileModel model)
    {
        if (model.File.Length == 0)
        {
            return BadRequest("File is missing.");
        }

        var fileName = model.File.FileName;

        using (var stream = new MemoryStream())
        {
            await model.File.CopyToAsync(stream);
            stream.Seek(0, SeekOrigin.Begin);
            
            await Mediator.Send(new FileUploadCommand
            {
                FileStream = stream,
                FileName = fileName
            });
        }

        return Ok();
    }

}