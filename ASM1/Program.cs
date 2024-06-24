using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ASM1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while(!exit) 
            {
                Menu();
                string choice = GetChoice();
                string name = GetName();
                
                if (choice == "5") 
                {
                    break;
                }
                
                int last_month = Number("Enter water usage last month: ");
                Console.WriteLine("Water usage last month: " + last_month + "m³");
                int this_month = Number("Enter water usage this month: ");
                Console.WriteLine("Water usage this month: " + this_month + "m³");

                if (last_month >= this_month)
                {
                    Console.WriteLine("Invalid input. Please try again..!");
                    continue;
                }

                int consumption;
                consumption = this_month - last_month;
                if (choice == "1") 
                {
                    int NumberOfPeople = int.Parse(Console.ReadLine());
                    double m3 = consumption / NumberOfPeople;
                    Console.WriteLine("The average amount of water used by each person is: " + m3 + "m3");
                }
                Console.WriteLine("Water consumption is: " + consumption + " m3");

                double waterPrice = GetWaterPrice(choice, consumption);
                Console.WriteLine("Total water bill: " + waterPrice + " VND");
                double envFee = waterPrice * 0.1;
                Console.WriteLine("Environment Fee is: " + envFee + " VND");

                double VAT = waterPrice * 0.1;
                Console.WriteLine("VAT is: " + VAT + " VND");

                double totalBill;
                totalBill = waterPrice + VAT + envFee;
                Console.WriteLine("Total bill is: " + totalBill + " VND");

                Console.WriteLine("Please press enter key to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }
        // Hiện menu
        static void Menu()
        {
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1. HouseHold");
            Console.WriteLine("2. Business services");
            Console.WriteLine("3. Administrative agency, public services");
            Console.WriteLine("4. Production units");
            Console.WriteLine("5. Exit the program..!");
        }
        // kiểm tra các lựa chọn
        static string GetChoice() 
        {
            Console.WriteLine("Enter yourChoice: ");
            string choice = Console.ReadLine();
            while(choice != "1" && choice != "2" && choice != "3" && choice != "4") 
            {
                Console.WriteLine("There is no right type of customer. Please re-enter..!");
                choice = Console.ReadLine();
            }
            return choice;
        }
        // nhập vào tên khách hàng
        static string GetName() 
        {
            Console.WriteLine("Enter the customer name: ");
            string name = Console.ReadLine();
            return name;
        }     
        static int Number(string message)
        {
            Console.Write(message);
            int num = int.Parse(Console.ReadLine());
            return num;
        }
        // tính toán cho các loại khách hàng
        static double GetWaterPrice(string choice, int consumption) 
        {
            double waterPrice = 0;
            switch (choice) 
            {
                case "1":
                    if (consumption <= 10)
                    {
                        waterPrice = 5.973 * consumption;
                    }
                    else if (consumption <= 20)
                    {
                        waterPrice = (10 * 5.973) + ((consumption - 10) * 7.052);
                    }
                    else if (consumption <= 30)
                    {
                        waterPrice = (10 * 5.973) + (10 * 7.052) + ((consumption - 20) * 8.699);
                    }
                    else 
                    {
                        waterPrice = (10 * 5.973) + (10 * 7.052) + (10 * 8.699) + ((consumption - 30) * 15.929);
                    }
                    break;
                case "2":
                    waterPrice = consumption * 22.068;
                    break;
                case "3":
                    waterPrice = consumption * 9.955;
                    break;
                case "4":
                    waterPrice = consumption * 11.615;
                    break;
                case "5":
                    Console.WriteLine("Exit the programm..!");
                    Environment.Exit(0);
                    break;
            }
            return waterPrice;
        }
    }
}
