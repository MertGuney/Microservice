using FreeCourse.Services.Basket.Services;
using FreeCourse.Shared.Messages;
using FreeCourse.Shared.Services;
using MassTransit;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Services.Basket.Consumer
{
    public class CourseNameChangedEventConsumer : IConsumer<CourseNameChangedEvent>
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public CourseNameChangedEventConsumer(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task Consume(ConsumeContext<CourseNameChangedEvent> context)
        {
            var basketItems = await _basketService.GetBasket("0a21935a-dbce-4646-a5cb-c6ba2d0a6f26");
            var updateBasketItem = basketItems.Data.BasketItems.Where(x => x.CourseId == context.Message.CourseId).FirstOrDefault();
            updateBasketItem.UpdateBasketItem(context.Message.UpdatedName, context.Message.Price, updateBasketItem.Quantity);
            await _basketService.SaveOrUpdate(basketItems.Data);
        }
    }
}
