namespace WebApplicationCourse.Models
{
    public class Cart
    {
        public List<PositionCart> PositionsCart = new List<PositionCart>();
        public decimal Cost { get; set; }
        public void AddPositionToCart(PositionCart positionCart)
        {
            PositionsCart.Add(positionCart);
            Cost += positionCart.Total;
        }
        public void RemovePositionFromCart(PositionCart positionCart)
        {
            PositionsCart.Remove(positionCart);
            Cost -= positionCart.Total;
        }
    }
}
