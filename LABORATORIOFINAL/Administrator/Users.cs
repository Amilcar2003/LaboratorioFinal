using System;
using LABORATORIOFINAL.Model;

namespace LABORATORIOFINAL.Administrator
{
    class Users
    {
        public void users()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine("USUARIOS");
            Console.WriteLine("------------------------");
            Console.WriteLine("------------------------");
            Console.WriteLine("1. Ver Todos los Usuarios");
            Console.WriteLine("2. Ver Administradores");
            Console.WriteLine("3. Crear Administrador");
            Console.WriteLine("4. Ver Trabajadores");
            Console.WriteLine("5. Crear Trabajador");
            Console.WriteLine("6. Regresar");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                getAll();
            }
            else if (option == 2)
            {
                getAdministrators();
            }
            else if (option == 3)
            {
                createAdministrator();
            }
            else if (option == 4)
            {
                getEmployees();
            }
            else if (option == 5)
            {
                createEmployee();
            }
            else if (option == 6)
            {
                new Administrator().menu();
            }
            else
            {
                users();
            }
        }

        public void getAll()
        {
            Console.Clear();
            Console.WriteLine("LISTA DE USUARIOS");
            Console.WriteLine("---------------------");
            for (int i = 0; i < User.users.Count; i++)
            {
                Console.WriteLine("Usuario: " + User.users[i].Username);
                Console.WriteLine("Contraseña: " + User.users[i].Password);
                Console.WriteLine("Rol: " + User.users[i].Role);
                Console.WriteLine("---------------------");
            }
            Console.WriteLine();
            Console.Write("Presiona cualquier tecla para continuar...");
            Console.ReadLine();
            users();
        }

        public void getAdministrators()
        {
            Console.Clear();
            Console.WriteLine("LISTA DE USUARIOS (administradores)");
            Console.WriteLine("---------------------");
            for (int i = 0; i < User.users.Count; i++)
            {
                if (User.users[i].Role == "admin")
                {
                    Console.WriteLine("Usuario: " + User.users[i].Username);
                    Console.WriteLine("Contraseña: " + User.users[i].Password);
                    Console.WriteLine("Rol: " + User.users[i].Role);
                    Console.WriteLine("---------------------");
                }
            }
            Console.WriteLine();
            Console.Write("Presiona cualquier tecla para continuar...");
            Console.ReadLine();
            users();
        }

        public void createAdministrator()
        {
            Console.Clear();
            Console.Write("Ingresa el usuario: ");
            string username = Console.ReadLine();
            Console.Write("Ingresa la contraseña: ");
            string password = Console.ReadLine();
            User.users.Add(new User() { Username = username, Password = password, Role = "admin" });
            Console.WriteLine("----------------");
            Console.WriteLine("Usuario creado");
            Console.WriteLine("----------------");
            Console.WriteLine();
            Console.Write("Presiona cualquier tecla para continuar...");
            Console.ReadLine();
            users();
        }

        public void getEmployees()
        {
            Console.Clear();
            Console.WriteLine("LISTA DE USUARIOS (trabajadores)");
            Console.WriteLine("---------------------");
            for (int i = 0; i < User.users.Count; i++)
            {
                if (User.users[i].Role == "employee")
                {
                    Console.WriteLine("Usuario: " + User.users[i].Username);
                    Console.WriteLine("Contraseña: " + User.users[i].Password);
                    Console.WriteLine("Rol: " + User.users[i].Role);
                    Console.WriteLine("---------------------");
                }
            }
            Console.WriteLine();
            Console.Write("Presiona cualquier tecla para continuar...");
            Console.ReadLine();
            users();
        }

        public void createEmployee()
        {
            Console.Clear();
            Console.Write("Ingresa el usuario: ");
            string username = Console.ReadLine();
            Console.Write("Ingresa la contraseña: ");
            string password = Console.ReadLine();
            User.users.Add(new User() { Username = username, Password = password, Role = "employee" });
            Console.WriteLine("----------------");
            Console.WriteLine("Usuario creado");
            Console.WriteLine("----------------");
            Console.WriteLine();
            Console.Write("Presiona cualquier tecla para continuar...");
            Console.ReadLine();
            users();
        }
    }
}
