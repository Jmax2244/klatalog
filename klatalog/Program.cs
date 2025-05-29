using System;

namespace klatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("wprowadz pojemnosc magazynu: ");
            int capacity = int.Parse(Console.ReadLine());
            Console.Write("wprowadz maksymalna wage (kg): ");
            double maxWeight = double.Parse(Console.ReadLine());

            Warehouse warehouse = new Warehouse(capacity, maxWeight);

            while (true)
            {
                Console.WriteLine("\nwybierz opcje:");
                Console.WriteLine("1. dodaj item");
                Console.WriteLine("2. pokaz wszystkie itemy");
                Console.WriteLine("3. usun item po nazwie");
                Console.WriteLine("4. lista delikatnych i ciezkich itemow");
                Console.WriteLine("5. srednia dziwnosc");
                Console.WriteLine("0. wyjdz");
                Console.Write("> ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("nazwa: ");
                    string name = Console.ReadLine();
                    Console.Write("waga (kg): ");
                    double weight = double.Parse(Console.ReadLine());
                    Console.Write("dziwnosc (1-10): ");
                    int weirdness = int.Parse(Console.ReadLine());
                    Console.Write("delikatny? (true/false): ");
                    bool isDelicate = bool.Parse(Console.ReadLine());

                    Item item = new Item(name, weight, weirdness, isDelicate);
                    bool success = warehouse.AddItem(item);
                }
                else if (choice == "2")
                {
                    warehouse.ListAll();
                }
                else if (choice == "3")
                {
                    Console.Write("nazwa itemu: ");
                    string name = Console.ReadLine();
                    warehouse.RemoveItem(name);
                }
                else if (choice == "4")
                {
                    Console.Write("wprowadz próg wagi: ");
                    double threshold = double.Parse(Console.ReadLine());
                    warehouse.ListDelicateOrHeavy(threshold);
                }
                else if (choice == "5")
                {
                    Console.WriteLine("srednia dziwnosc: " + warehouse.CalculateAverageWeirdness());
                }
                else if (choice == "0")
                {
                    break;
                }
            }
        }
    }
}
