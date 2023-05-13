using MediatR;
using Microsoft.AspNetCore.Http;
using OI.Template.Domain.Repository;

namespace OI.Template.Application.File.Commands.FileUpload;

public record FileUploadCommand : IRequest
{
    public Stream FileStream { get; set; }
    public string FileName { get; set; }
}

public class FileUploadCommandHandler : IRequestHandler<FileUploadCommand>
{
    private readonly IBlobStorageRepository _blobStorageRepository;

    public FileUploadCommandHandler(IBlobStorageRepository blobStorageRepository)
    {
        _blobStorageRepository = blobStorageRepository;
    }

    public async Task Handle(FileUploadCommand request, CancellationToken cancellationToken)
    {
        await _blobStorageRepository.UploadFile(request.FileStream, request.FileName);
    }
}