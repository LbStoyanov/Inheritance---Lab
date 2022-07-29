using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {

        public Table()
        {
            
        }
        public int TableNumber { get; }
        public int Capacity { get; }
        public int NumberOfPeople { get; }
        public decimal PricePerPerson { get; }
        public bool IsReserved { get; }
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
