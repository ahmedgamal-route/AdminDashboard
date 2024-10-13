using Microsoft.AspNetCore.Mvc;
using Services.Helpers;

namespace E_Commerce.Controllers
{

    public class DocumentController : BaseController
    {
        [HttpPost]
        public ActionResult<string> UploadFile(IFormFile file, string folderName)
            => DocumentSettings.UploadFile(file, folderName);

        [HttpPost]
        public ActionResult<bool> DeleteFile(string PictureUrl, string folderName)
           => DocumentSettings.DeleteFile(PictureUrl, folderName);

    }
}
