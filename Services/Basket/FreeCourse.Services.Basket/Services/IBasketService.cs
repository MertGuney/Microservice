using FreeCourse.Services.Basket.DTOs;
using FreeCourse.Shared.DTOs;
using System.Threading.Tasks;

namespace FreeCourse.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDTO>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDTO basketDTO);
        Task<Response<bool>> DeleteBasket(string userId);
    }
}
