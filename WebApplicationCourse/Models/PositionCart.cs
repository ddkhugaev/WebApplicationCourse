namespace WebApplicationCourse.Models
{
    public class PositionCart
    {
        public Product Prod { get; set; }
        public int Count { get; set; }
        public decimal Total { get; set; }
        public PositionCart(Product prod, int count)
        {
            Prod = prod;
            Count = count;
            Total = Prod.Cost * count;
        }
        public void IncreaseCount(int count)
        {
            Count += count;
            Total = Prod.Cost * Count;
        }
        public void DecreaseCount(int count)
        {
            Count -= count;
            Total = Prod.Cost * Count;
        }
    }
}
