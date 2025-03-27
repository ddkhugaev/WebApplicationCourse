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
            Id = Guid.NewGuid();
            Prod = prod;
            Count = count;
            Total = Prod.Cost * count;
        }
        public void IncreaseCount()
        {
            Count++;
            Total = Prod.Cost * Count;
        }
        public void DecreaseCount()
        {
            if (Count > 0)
            {
                Count--;
                Total = Prod.Cost * Count;
            }
        }
    }
}
