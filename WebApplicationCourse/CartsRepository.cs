using WebApplicationCourse.Models;

namespace WebApplicationCourse
{
    public static class CartsRepository
    {
        static List<Cart> carts = new List<Cart>();
        public static Cart TryGetById(string userId)
        {
            return carts.FirstOrDefault(cart => cart.UserId == userId);
        }
        public static List<Cart> GetAll()
        {
            return carts;
        }
        public static void Add(Product product, string userId)
        {
            var existingCart = TryGetById(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    ItemsCart = new List<ItemCart>
                    {
                        new ItemCart(product, 1)
                    }
                };
                carts.Add(newCart);
            }
            else
            {
                var existingItemCart = existingCart.ItemsCart.FirstOrDefault(itemCart => itemCart.Prod.Id == product.Id);
                if (existingItemCart != null)
                {
                    existingItemCart.IncreaseCount(1);
                }
                else
                {
                    existingCart.AddPositionToCart(new ItemCart(product, 1));
                }
            }
        }
    }
}
