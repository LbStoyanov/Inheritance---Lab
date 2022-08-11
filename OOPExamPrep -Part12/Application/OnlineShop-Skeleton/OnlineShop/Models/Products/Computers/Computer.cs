using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product,IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();
        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();
        public void AddComponent(IComponent component)
        {
            if (this.components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(
                    string.Format(
                        ExceptionMessages.InvalidComponentType,
                        component.GetType().Name,this.GetType().Name,this.Id));
            }

            this.components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.components.Count == 0 || this.Components.All(x => x.GetType().Name != componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent,componentType,this.GetType().Name,this.Id));
            }

            IComponent component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);

            this.components.Remove(component);

            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Contains(peripheral))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.components.Count == 0 || this.Components.All(x => x.GetType().Name != peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            IPeripheral peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            //May need use Foreach for every component and peripheral!!!
            return base.ToString() + (string.Format(SuccessMessages.ComputerComponentsToString,this.Components.Count)) + this.Peripherals.ToString();
        }
    }
}
