namespace AdminDashboard.Services
{
    public interface IDocumentService
    {
        Task<string> UploadFileAsync(IFormFile file, string folderName);

        Task<bool> DeleteFileAsync(string PictureUrl, string folderName);
    }
}
