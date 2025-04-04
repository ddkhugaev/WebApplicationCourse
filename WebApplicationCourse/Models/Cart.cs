using Microsoft.AspNetCore.SignalR;

namespace WebApplicationCourse.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = Constants.UserId;

        public List<ItemCart> ItemsCart = new List<ItemCart>();
        public decimal Cost { 
            get
            {
                return ItemsCart?.Sum(itemCart => itemCart.Total) ?? 0;
            }
        }
        public int Amount
        {
            get
            {
                return ItemsCart?.Sum(itemCart => itemCart.Count) ?? 0;
            }
        }
        public void AddPositionToCart(ItemCart itemCart)
        {
            ItemsCart.Add(itemCart);
        }
        public void RemovePositionFromCart(ItemCart positionCart)
        {
            ItemsCart.Remove(positionCart);
        }
    }
}
