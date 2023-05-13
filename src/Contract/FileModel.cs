using Microsoft.AspNetCore.Http;

namespace OI.Template.Contract;

public record FileModel 
{
    public IFormFile File { get; set; }
}