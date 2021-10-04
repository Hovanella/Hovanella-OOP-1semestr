using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba6
{
    public class Gym
    {
        private readonly int _budget;
        private readonly int _demandCapacity;

        public Gym()
        {
            _budget = CurrentBudget = 1000;
            CurrentCapacity = 0;
            _demandCapacity = 5;
            InventoryList = new List<Inventory>();
        }

        public Gym(int budget)
        {
            _budget = CurrentBudget = budget;
            CurrentCapacity = 0;
            _demandCapacity = 5;
            InventoryList = new List<Inventory>();
        }

        public Gym(int budget, int demandCapacity, params Inventory[] items)
        {
            var inventoryList = items.ToList();

            _budget = budget;
            _demandCapacity = demandCapacity;

            int itemsCost = inventoryList.Sum(item => item.Cost);
            if (itemsCost > budget)
                throw new ArgumentException();

            CurrentBudget = _budget - itemsCost;
            InventoryList = inventoryList;
            CurrentCapacity = items.Length;
            IsEquiped = CurrentCapacity >= _demandCapacity;

            SortInventoryList();
        }

        public List<Inventory> InventoryList { get; set; }
        public bool IsEquiped { get; private set; }
        public int CurrentCapacity { get; private set; }
        public int CurrentBudget { get; private set; }

        public void PringInventoryList()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                $"----------------------\nGym: current capatity - {CurrentCapacity}, budget - {_budget}, current budget - {CurrentBudget} , Is equiped - {IsEquiped}(demand capacity - {_demandCapacity})");
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var item in InventoryList) Console.WriteLine(item.ToString());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------------------");
        }

        public void Add(Inventory item)
        {
            if (item.Cost > CurrentBudget)
                throw new ArgumentException();

            InventoryList.Add(item);
            CurrentBudget -= item.Cost;
            CurrentCapacity++;
            if (CurrentCapacity >= _demandCapacity)
                IsEquiped = true;
            SortInventoryList();
        }

        public void Delete(Inventory item)
        {
            int cost = item.Cost;
            if (InventoryList.Remove(item))
            {
                CurrentBudget += cost;
                CurrentCapacity--;
                if (CurrentCapacity < _demandCapacity)
                    IsEquiped = false;
            }

            SortInventoryList();
        }

        private void SortInventoryList()
        {
            InventoryList = InventoryList.OrderBy(x => x.Cost).ToList();
        }
    }
}