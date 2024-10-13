
namespace AdminDashboard.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<DocumentService> _logger;

        public DocumentService(IConfiguration config, ILogger<DocumentService> logger)
        {
            _config = config;
            _logger = logger;
        }
        public async Task<bool> DeleteFileAsync(string PictureUrl, string folderName)
        {
            using var _httpClient = new HttpClient();
            var response = await _httpClient.PostAsync($"{_config["BaseUrl"]}api/Document/DeleteFile?PictureUrl={PictureUrl}&folderName={folderName}", null);
            response.EnsureSuccessStatusCode();

            var responseData= await response.Content.ReadAsStringAsync();

            return bool.TryParse(responseData, out var result)&& result;
        }

        public async Task<string> UploadFileAsync(IFormFile file, string folderName)
        {
            try
            {

                using var _httpClient = new HttpClient();
                using var form = new MultipartFormDataContent();
                using var fileContent = new StreamContent(file.OpenReadStream());


                form.Add(fileContent, "file", file.FileName);

                var response = await _httpClient.PostAsync($"{_config["BaseUrl"]}api/Document/UploadFile?folderName={folderName}", form);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
