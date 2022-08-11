using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private  List<IComputer> computers;
        private  List<IComponent> components;
        private  List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {

            IsComputerIdExist(id);

            if (computerType != "DesktopComputer" && computerType != "Laptop")
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            IComputer computer = null;

            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if(computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }

            this.computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
            
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            IsComputerIdExist(computerId);

            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (this.peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = null;

            if (peripheralType == "Keyboard")
            {

                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            this.peripherals.Add(peripheral);
            computer!.AddPeripheral(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IsComputerIdExist(computerId);

            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            IPeripheral peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (peripheral != null)
            {
                computer.RemovePeripheral(peripheralType);
                return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
            }

            return "";
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            //IsComputerIdExist(computerId);

            IComputer computer = this.computers.FirstOrDefault(computer => computer.Id == computerId);

            if (computer!.Components.Any(x=> x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = null;

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            this.components.Add(component);
            computer.AddComponent(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IsComputerIdExist(computerId);

            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            IComponent component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);

            return computer.RemoveComponent(componentType).ToString();

        }

        public string BuyComputer(int id)
        {
            IsComputerIdExist(id);

            IComputer computer = this.computers.FirstOrDefault(x => x.Id == id);

            this.computers.Remove(computer);

            return computer!.ToString();
        }

        public string BuyBest(decimal budget)
        {
            var best = this.computers.OrderByDescending(x => x.OverallPerformance).Max();

            if (best.Price <= budget)
            {
                throw new ArgumentException($" Can't buy a computer with a budget of ${budget}.");
            }

            this.computers.Remove(best);

            return best.ToString();
            
        }

        public string GetComputerData(int id)
        {
            IsComputerIdExist(id);

            var computer = this.computers.FirstOrDefault(x => x.Id == id);

            return computer.ToString();
        }

        private void IsComputerIdExist(int id)
        {
            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComputerId, id));
            }
        }


    }
}
