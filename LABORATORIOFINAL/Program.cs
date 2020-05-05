using LABORATORIOFINAL.Model;

namespace LABORATORIOFINAL
{
    class Program
    {
        static void Main(string[] args)
        {

            User.users.Add(new User() { Username = "Carlos", Password = "456", Role = "admin" });
            User.users.Add(new User() { Username = "amilcar", Password = "123", Role = "employee" });
            Product.products.Add(new Product() { Name = "Computadora", Price = 6000, Stock = 100 });
            Product.products.Add(new Product() { Name = "Videojuegos", Price = 500, Stock = 100 });

            new Login().menu();
        }
    }
}
