using System.ComponentModel.DataAnnotations;

namespace WebApplicationCourse.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Введите адрес")]
        public string Address { get; set; }
        public Cart CartOrder { get; set; } = new Cart();
        //public Order(string name, string phone, string address, Cart cartOrder)
        //{
        //    Id = Guid.NewGuid();
        //    Name = name;
        //    Phone = phone;
        //    Address = address;
        //    CartOrder = cartOrder;
        //}

        // добавлено позже
        public OrderStatus Status { get; set; }
        public DateTime OrderTime;
        public string UserName = "Заглушка пользователя в заказе";
        public string Commentary = "Заглушка комментария в заказе";
        public Order()
        {
            OrderTime = DateTime.Now;
            Status = OrderStatus.Created;
        }
        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nPhone: {Phone}\nAddress: {Address}\nCartOrder:\n{CartOrder}";
        }
    }
}
