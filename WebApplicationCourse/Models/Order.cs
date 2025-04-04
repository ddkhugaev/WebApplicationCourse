namespace WebApplicationCourse.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Cart CartOrder { get; set; }
        public Order(string name, string phone, string address, Cart cartOrder)
        {
            Id = Guid.NewGuid();
            Name = name;
            Phone = phone;
            Address = address;
            CartOrder = cartOrder;
        }
    }
}
