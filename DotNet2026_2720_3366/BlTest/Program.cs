

using System;
using System.Collections.Generic;
using System.Linq;
using BO;
using static BO.BlException;

namespace BlTest
{
    internal class Program
    {
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

        static void Main(string[] args)
        {
            try
            {
                DalTest.Initialization.Initialize();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Initialization failed: " + ex.Message);
            }

            Console.WriteLine("Hello customer!");

            Console.WriteLine("Insert customer ID:");
            int customerId = int.Parse(Console.ReadLine());

            try
            {
                var customer = s_bl.Customer.Read(customerId);
                if (customer == null)
                {
                    Console.WriteLine("The customer does not exist.");
                    return;
                }
            }
            catch (BlIdNotExistsException e)
            {
                e.ToString();
             
            }

            Console.WriteLine("Are you a club member?");
            Console.WriteLine("1 - Yes");
            Console.WriteLine("0 - No");

            bool club = Console.ReadLine() == "1";

            Order order = new Order()
            {
                preferredCustomer = club,
                ProductsOnOrder = new List<ProductInOrder>(),
                TotalPrice = 0
            };

            int choice;

            do
            {
                Console.WriteLine();
                Console.WriteLine("===== Order Menu =====");
                Console.WriteLine("1 - Adding a product to an order");
                Console.WriteLine("2 - Show order");
                Console.WriteLine("3 - Final price");
                Console.WriteLine("4 - Placing an order");
                Console.WriteLine("0 - Exit");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Insert productId:");
                            int productId = int.Parse(Console.ReadLine());

                            Console.WriteLine("Insert amount:");
                            int amount = int.Parse(Console.ReadLine());

                            // 1. הוספת המוצר וקבלת המבצעים
                            var sales = s_bl.Order.AddProductToOrder(order, productId, amount);

                            // 2. עדכון ה-TotalPrice של ה-order אצלנו ב-Program באמצעות ref
                            s_bl.Order.CalcTotalPrice(ref order);

                            Console.WriteLine("The product has been added to the order.");

                            if (sales != null && sales.Count > 0)
                            {
                                Console.WriteLine("Deals found:");
                                foreach (var sale in sales)
                                {
                                    Console.WriteLine($"Sale ID: {sale.SaleId}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("There are no sales for this product.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 2:
                        Console.WriteLine("===== Order =====");

                        if (order.ProductsOnOrder == null || order.ProductsOnOrder.Count == 0)
                        {
                            Console.WriteLine("No products in the order");
                            break;
                        }

                        foreach (var item in order.ProductsOnOrder)
                        {
                            Console.WriteLine($"Product ID: {item.ProductId}");
                            Console.WriteLine($"Product Name: {item.ProductName}");
                            Console.WriteLine($"Quantity: {item.AmountInOrder}");
                            Console.WriteLine($"BasePrice: {item.BasicPrice}");
                            Console.WriteLine($"FinalPrice: {item.TotalPrice}");

                            Console.WriteLine("Sales:");
                            if (item.ListOfSales != null)
                            {
                                foreach (var sale in item.ListOfSales)
                                {
                                    Console.WriteLine($"Sale ID: {sale.SaleId}");
                                }
                            }
                            Console.WriteLine();
                        }
                        break;

                    case 3:
                        Console.WriteLine($"Final price for the order: {order.TotalPrice}");
                        break;

                    case 4:
                        try
                        {
                            s_bl.Order.DoOrder(order);
                            Console.WriteLine("The order was placed successfully.");
                            order = new Order()
                            {
                                preferredCustomer = club,
                                ProductsOnOrder = new List<ProductInOrder>(),
                                TotalPrice = 0
                            };
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 0:
                        Console.WriteLine("Exit");
                        break;

                    default:
                        Console.WriteLine("Incorrect choice");
                        break;
                }

            } while (choice != 0);
        }
    }
}