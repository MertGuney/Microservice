using FreeCourse.Services.PhotoStock.DTOs;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FreeCourse.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        // cancellation token alma amacımız
        // kullanıcı eğer işlem devam ederken işlemi iptal eder veya sayfayı kapatırsa cancellationtoken tetiklenecek ve işlem devam etmeyecek
        [HttpPost]
        public async Task<IActionResult> Save(IFormFile photo, CancellationToken cancellationToken)
        {
            if (photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await photo.CopyToAsync(stream, cancellationToken);
                }
                var returnPath = photo.FileName;
                PhotoDTO photoDTO = new()
                {
                    Url = returnPath
                };
                return CreateActionResultInstance(Response<PhotoDTO>.Success(photoDTO, 200));
            }
            return CreateActionResultInstance(Response<PhotoDTO>.Fail("Photo is empty", 400));
        }
        [HttpGet]
        public IActionResult Delete(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photoUrl);
            //path var mı yok mu ?
            if (!System.IO.File.Exists(path))
            {
                return CreateActionResultInstance(Response<NoContent>.Fail("Photo Not Found", 404));
            }
            System.IO.File.Delete(path);
            return CreateActionResultInstance(Response<NoContent>.Success(204));
        }
    }
}
