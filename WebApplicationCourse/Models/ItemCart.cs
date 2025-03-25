namespace WebApplicationCourse.Models
{
    public class ItemCart
    {
        public Guid Id { get; set; }
        public Product Prod { get; set; }
        public int Count { get; set; }
        public decimal Total { get; set; }
        public ItemCart(Product prod, int count)
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
