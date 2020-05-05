using System;

namespace LABORATORIOFINAL.Administrator
{
    class Administrator
    {
        public void menu()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine("PANEL - ADMINISTRATOR");
            Console.WriteLine("------------------------");
            Console.WriteLine("------------------------");
            Console.WriteLine("1. Usuarios");
            Console.WriteLine("2. Inventario");
            Console.WriteLine("3. Facturación");
            Console.WriteLine("4. Cerrar Sesion");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                new Users().users();
            }
            else if (option == 2)
            {
                new Products().products();
            }
            else if (option == 3)
            {
                new Invoices().invoices();
            }
            else if (option == 4)
            {
                new Login().menu();
            }
            else
            {
                menu();
            }
        }
    }
}
