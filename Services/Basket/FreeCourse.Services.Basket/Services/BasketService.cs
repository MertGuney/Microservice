using FreeCourse.Services.Basket.DTOs;
using FreeCourse.Shared.DTOs;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreeCourse.Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> DeleteBasket(string userId)
        {
            var status = await _redisService.GetDatabase().KeyDeleteAsync(userId);
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket Not Found", 404);
        }

        public async Task<Response<BasketDTO>> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDatabase().StringGetAsync(userId);
            if (String.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDTO>.Fail("Basket Not Found", 404);
            }
            return Response<BasketDTO>.Success(JsonSerializer.Deserialize<BasketDTO>(existBasket), 200);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDTO basketDTO)
        {
            var status = await _redisService.GetDatabase().StringSetAsync(basketDTO.UserId, JsonSerializer.Serialize(basketDTO));
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket Could Not Update Or Save", 500);
        }
    }
}
