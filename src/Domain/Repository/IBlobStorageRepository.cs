namespace OI.Template.Domain.Repository;

public interface IBlobStorageRepository
{
    Task<string> UploadFile(Stream fileStream, string fileName);
}