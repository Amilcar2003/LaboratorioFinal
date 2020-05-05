﻿using System;
using LABORATORIOFINAL.Administrator;
using System.Text;
using System.IO;
using LABORATORIOFINAL.Model;

namespace LABORATORIOFINAL.Employee
{
    class Employee
    {
        public void menu()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine("PANEL - TRABAJADOR");
            Console.WriteLine("------------------------");
            Console.WriteLine("------------------------");
            Console.WriteLine("1. Cargar Producto");
            Console.WriteLine("2. Facturación");
            Console.WriteLine("3. Cerrar Sesion");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                updateStock();
            }
            else if (option == 2)
            {
                createInvoice();
            }
            else if (option == 3)
            {
                new Login().menu();
            }
            else
            {
                menu();
            }
        }

        public void updateStock()
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
                    menu();
                }
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Producto Inexistente");
            Console.WriteLine("-----------------------");
            Console.Write("Presiona cualquier tecla para continuar...");
            Console.ReadLine();
            menu();
        }

        public void createInvoice()
        {
            Console.Clear();
            string other;
            do
            {
                addProduct();
                Console.Write("¿Desea agregar otro producto? (s/n)");
                other = Console.ReadLine();
                if (other == "n")
                {
                    break;
                }
            } while (other == "s");
            Console.Write("Nombre de Cliente: ");
            string name = Console.ReadLine();
            Console.Write("Nit de Cliente: ");
            string nit = Console.ReadLine();

            Details.codF = Details.codF + 1;
            string noInvoice = "F000" + Details.codF;
            using (StreamWriter sw = File.CreateText(noInvoice + ".txt"))
            {
                sw.WriteLine("FACTURA - " + noInvoice);
                sw.WriteLine("----------------------------");
                sw.WriteLine("Nombre de Cliente: " + name);
                sw.WriteLine("Nit de Cliente: " + nit);
                sw.WriteLine("Fecha: " + DateTime.Now);

                sw.WriteLine("");
                sw.WriteLine("Detalles de Factura");
                sw.WriteLine("----------------------------");
                for (int i = 0; i < Details.deails.Count; i++)
                {
                    sw.WriteLine("Producto: " + Details.deails[i].Product);
                    sw.WriteLine("Precio: Q" + Details.deails[i].Price);
                    sw.WriteLine("Cantidad: " + Details.deails[i].Quantify);
                    sw.WriteLine("SubTotal: Q" + (double.Parse(Details.deails[i].Price) * double.Parse(Details.deails[i].Quantify)));
                    sw.WriteLine("----------------------------");
                }
                sw.WriteLine("TOTAL: Q" + getTotal());
            }
            Details.deails.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("FACTURA - " + noInvoice + " generada con exito!");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.Write("Presiona cualquier tecla para continuar...");
            Console.ReadLine();
            menu();
        }

        public void addProduct()
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
            Console.Write("Ingresa el nombre de producto: ");
            string name = Console.ReadLine();
            for (int i = 0; i < Product.products.Count; i++)
            {
                if (Product.products[i].Name == name)
                {
                    Console.Write("Ingresa cantidad a facturar: ");
                    int quantity = int.Parse(Console.ReadLine());
                    if (quantity > Product.products[i].Stock)
                    {
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("ERROR");
                        Console.WriteLine("La Cantidad debe ser menor a las existencias");
                        Console.WriteLine("----------------------------");
                        Console.WriteLine();
                        return;
                    }
                    else
                    {
                        Product.products[i].Stock = Product.products[i].Stock - quantity;
                        Details.deails.Add(new Details() { Product = Product.products[i].Name, Price = Product.products[i].Price.ToString(), Quantify = quantity.ToString() });

                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Producto Agregado al carrito");
                        Console.WriteLine("----------------------------");
                        Console.WriteLine();
                        return;
                    }
                }
            }
            Console.WriteLine("Producto no existente");
        }

        static double getTotal()
        {
            double total = 0;
            for (int i = 0; i < Details.deails.Count; i++)
            {
                total = total + (double.Parse(Details.deails[i].Price) * double.Parse(Details.deails[i].Quantify));
            }
            return total;
        }
    }
}
