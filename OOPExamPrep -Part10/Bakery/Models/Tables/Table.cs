using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly ICollection<IBakedFood> foodOrders;
        private readonly ICollection<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;
        private bool isReserved;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
            this.isReserved = false;
            
        }
        public int TableNumber { get; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0 )
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }
        public decimal PricePerPerson { get; }

        public bool IsReserved
            => this.isReserved;

        public decimal Price
            => foodOrders.Select(f => f.Price).Sum()
               + drinkOrders.Select(f => f.Price).Sum()
               + this.NumberOfPeople * this.PricePerPerson;

        public void Reserve(int numberOfPeople)
        {
           // this.Capacity -= numberOfPeople;
            this.isReserved = true;
            this.numberOfPeople = numberOfPeople;
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            //decimal result = 0.0m;
            //result += this.numberOfPeople * this.PricePerPerson;


            //foreach (var food in foodOrders)
            //{
            //    var currentFoodPrice = food.Price;
            //    result += currentFoodPrice;
            //}

            //foreach (var drink in drinkOrders)
            //{
            //    var currentDrinkPrice = drink.Price;
            //    result += currentDrinkPrice;
            //}

            

            //return result;

            return this.Price;
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.isReserved = false;
            this.numberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Table: {this.TableNumber}");
            result.AppendLine($"Type: {this.GetType().Name}");
            result.AppendLine($"Capacity: {this.Capacity}");
            result.AppendLine($"Price per Person: {this.PricePerPerson}");



            return result.ToString().TrimEnd();
        }
    }
}
