using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCourse.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        readonly ICartsRepository cartsRepository;

        public CartViewComponent(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetById(Constants.UserId);
            var productCount = cart?.Amount ?? 0;

            return View("Cart", productCount);
        }
    }
}
