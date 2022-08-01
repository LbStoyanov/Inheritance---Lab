using System;
using System.Collections.Generic;
using System.Data;
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
        private List<BakedFood> foodOrders;
        private List<Drink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<BakedFood>();
        }
        public int TableNumber { get; }

        public int Capacity
        {
            get { return this.capacity; }
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
            => this.capacity == 0 ?true:false;
                
        public decimal Price { get; }
            
        public void Reserve(int numberOfPeople)
        {
            throw new NotImplementedException();
        }

        public void OrderFood(IBakedFood food)
        {
            throw new NotImplementedException();
        }

        public void OrderDrink(IDrink drink)
        {
            throw new NotImplementedException();
        }

        public decimal GetBill()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public string GetFreeTableInfo()
        {
            throw new NotImplementedException();
        }
    }
}
