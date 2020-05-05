using System;
using LABORATORIOFINAL.Model;

namespace LABORATORIOFINAL.Administrator
{
    class Products
    {
        public void products()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine("PRODUCTOS");
            Console.WriteLine("------------------------");
            Console.WriteLine("------------------------");
            Console.WriteLine("1. Ver Todos los Productos");
            Console.WriteLine("2. Cargar Producto");
            Console.WriteLine("3. Regresar");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                getProducts();
            }
            else if (option == 2)
            {
                createProduct();
            }
            else if (option == 3)
            {
                new Administrator().menu();
            }
            else
            {
                products();
            }
        }

        public void getProducts()
        {
            Console.Clear();
            Console.WriteLine("LISTA DE PRODUCTOS");
            Console.WriteLine("---------------------");
            for (int i = 0; i < Product.products.Count; i++)
            {
                Console.WriteLine("Producto: " + Product.products[i].Name);
                Console.WriteLine("Precio: " + Product.products[i].Price);
                Console.WriteLine("Existencias: " + Product.products[i].Stock);
                Console.WriteLine("---------------------");
            }
            Console.WriteLine();
            Console.Write("Presiona cualquier tecla para continuar...");
            Console.ReadLine();
            products();
        }

        public void createProduct()
        {
            Console.Clear();
            Console.Write("Ingresa el nombre: ");
            string name = Console.ReadLine();
            for (int i = 0; i < Product.products.Count; i++)
            {
                if (Product.products[i].Name == name)
                {
                    Console.Write("Ingresa cantidad a cargar: ");
                    int new_stock = int.Parse(Console.ReadLine());
                    Product.products[i].Stock = Product.products[i].Stock + new_stock;
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Existencia Actualizada");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine();
                    Console.Write("Presiona cualquier tecla para continuar...");
                    Console.ReadLine();
                    products();
                }
            }
            Console.Write("Ingresa el precio: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Ingresa existencias: ");
            int stock = int.Parse(Console.ReadLine());
            Product.products.Add(new Product() { Name = name, Price = price, Stock = stock });
            Console.WriteLine("----------------");
            Console.WriteLine("Producto creado");
            Console.WriteLine("----------------");
            Console.WriteLine();
            Console.Write("Presiona cualquier tecla para continuar...");
            Console.ReadLine();
            products();
        }
    }
}
