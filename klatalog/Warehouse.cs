using System;
using System.Collections.Generic;
using System.Linq;

namespace klatalog
{
    class Warehouse
    {
        private List<Item> items;
        private int capacity;
        private double maxWeight;

        public Warehouse(int capacity, double maxWeight)
        {
            this.capacity = capacity;
            this.maxWeight = Math.Round(maxWeight, 3);
            items = new List<Item>();
        }

        public bool AddItem(Item item)
        {
            if (items.Count >= capacity)
            {
                Console.WriteLine("blad, magazyn pelny");
                return false;
            }

            double currentWeight = items.Sum(i => i.WeightKg);
            if (currentWeight + item.WeightKg > maxWeight)
            {
                Console.WriteLine("blad: magazyn zapelniony");
                return false;
            }

            if (item.IsDelicate && item.WeirdnessLevel == 7 && items.Count >= capacity / 2)
            {
                Console.WriteLine("blad: zbyt niebiezpieczny item (delikatnosc i dziwnosc level 7)");
                return false;
            }

            items.Add(item);
            Console.WriteLine("Item dodany");
            return true;
        }

        public void ListAll()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("magazyn jest pusty");
                return;
            }

            foreach (var item in items)
            {
                Console.WriteLine(item.Description());
            }
        }

        public bool RemoveItem(string name)
        {
            var item = items.FirstOrDefault(i => i.Name == name);
            if (item != null)
            {
                items.Remove(item);
                Console.WriteLine("Item usuniety");
                return true;
            }
            Console.WriteLine("Item nie znaleziony");
            return false;
        }

        public void ListDelicateOrHeavy(double threshold)
        {
            var result = items.Where(i => i.IsDelicate || i.WeightKg > threshold).ToList();
            if (result.Count == 0)
            {
                Console.WriteLine("nie znaleziono itemkow");
            }
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.Description());
                }
            }
        }

        public double CalculateAverageWeirdness()
        {
            if (items.Count == 0)
                return 0;
            return Math.Round(items.Average(i => i.WeirdnessLevel), 3);
        }
    }
}
