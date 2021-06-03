using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceshipCrafting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> liquids = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();

            List<int> physicalItems = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();

            Dictionary<string, int> advancedMaterials = new Dictionary<string, int>();
            fillMaterialsValue(advancedMaterials);

            Dictionary<string, int> items = new Dictionary<string, int>();
            fillItemsCount(items);

            bool match = false;

            while (liquids.Count != 0 && physicalItems.Count != 0)
            {
                match = false;
                int sum = liquids[0] + physicalItems[^1];
                foreach (var material in advancedMaterials)
                {
                    if (material.Value == sum)
                    {
                        items[material.Key]++;
                        liquids.RemoveAt(0);
                        physicalItems.RemoveAt(physicalItems.Count - 1);
                        match = true;
                    }
                }
                if (!match)
                {
                    liquids.RemoveAt(0);
                    physicalItems[^1] += 3;
                }

            }
            int counter = 0;

            foreach (var item in items)
            {
                if (item.Value > 0)
                {
                    counter++;
                }
            }

            if (counter == items.Count)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                string liquidsLeft = String.Join(", ", liquids);
                Console.WriteLine($"Liquids left: {liquidsLeft}");
            }

            if (physicalItems.Count == 0)
            {
                Console.WriteLine("Physical items left: none");
            }
            else
            {
                physicalItems.Reverse();
                string physicalItemsLeft = String.Join(", ", physicalItems);
                Console.WriteLine($"Physical items left: {physicalItemsLeft}");
            }

            foreach (var item in items.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static void fillItemsCount(Dictionary<string, int> items)
        {
            items.Add("Glass", 0);
            items.Add("Aluminium", 0);
            items.Add("Lithium", 0);
            items.Add("Carbon Fiber", 0);
        }

        private static void fillMaterialsValue(Dictionary<string, int> advancedMaterials)
        {
            advancedMaterials.Add("Glass", 25);
            advancedMaterials.Add("Aluminium", 50);
            advancedMaterials.Add("Lithium", 75);
            advancedMaterials.Add("Carbon Fiber", 100);
        }
    }
}
