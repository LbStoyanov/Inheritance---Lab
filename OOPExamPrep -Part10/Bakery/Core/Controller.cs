using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> foodList;
        private List<IDrink> drinkList;
        private List<ITable> tableList;
        public Controller()
        {
                this.foodList = new List<IBakedFood>();
                this.drinkList = new List<IDrink>();
                this.tableList = new List<ITable>();
        }
        public string AddFood(string type, string name, decimal price)
        {
            if (type != "Bread" && type != "Cake")
            {
                return "";
            }

            IBakedFood food = null;

            if (type == "Bread")
            {
                food = new Bread(name, price);

            }
            else if(type == "Cake")
            {
                food = new Cake(name, price);
            }

            this.foodList.Add(food);

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type != "Tea" && type != "Water")
            {
                return "";
            }

            IDrink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion,brand);

            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            this.drinkList.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tableList.Add(table);

            return string.Format(OutputMessages.TableAdded, tableNumber);

        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tableList.FirstOrDefault(x => x.IsReserved == true && x.Capacity <= numberOfPeople);

            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);

            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            throw new NotImplementedException();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            throw new NotImplementedException();
        }

        public string LeaveTable(int tableNumber)
        {
            throw new NotImplementedException();
        }

        public string GetFreeTablesInfo()
        {
            throw new NotImplementedException();
        }

        public string GetTotalIncome()
        {
            throw new NotImplementedException();
        }
    }
}
