using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core.Contracts
{
    public class Controller : IController
    {
        private DecorationRepository decorationRepository;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorationRepository = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            IAquarium aquarium = null;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            this.aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Ornament" && decorationType != "Plant")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            IDecoration decoration = null;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else
            {
                decoration = new Plant();
            }

            this.decorationRepository.Add(decoration);


            return string.Format(OutputMessages.SuccessfullyAdded,decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if (!this.decorationRepository.Models.Any(x => x.GetType().Name == decorationType))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration,
                    decorationType));
            }

            IDecoration decoration = this.decorationRepository.FindByType(decorationType);

            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.AddDecoration(decoration);

            this.decorationRepository.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            IFish fish = null;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            aquarium.AddFish(fish);


            if (fish.GetType().Name == "FreshwaterFish" && aquarium.GetType().Name != "FreshwaterAquarium")
            {
                return OutputMessages.UnsuitableWater;
            }
            else if(fish.GetType().Name == "SaltwaterFish" && aquarium.GetType().Name != "SaltwaterAquarium")
            {
                return OutputMessages.UnsuitableWater;
            }

            

            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);

        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();

            var feededFishes = aquarium.Fish.Count;

            return string.Format(OutputMessages.FishFed, feededFishes);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();

            var sumOfAllFishesAndDecorations = 
                aquarium.Decorations.Select(x => x.Price).Sum() + aquarium.Fish.Select(f =>f.Price).Sum();

            return string.Format(OutputMessages.AquariumValue, sumOfAllFishesAndDecorations);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                result.AppendLine(aquarium.GetInfo());
            }

            return result.ToString().TrimEnd();
        }
    }
}
