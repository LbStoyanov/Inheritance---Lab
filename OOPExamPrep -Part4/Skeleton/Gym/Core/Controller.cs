using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Equipment;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipmentRepository;
        private readonly ICollection<Gym.Models.Gyms.Gym> gyms;
        public Controller()
        {
            this.equipmentRepository = new EquipmentRepository();
            this.gyms = new List<Gym.Models.Gyms.Gym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {

            var gym = gyms.FirstOrDefault(g => g.Name == gymName);

            if (athleteType == "Boxer")
            {
                Boxer boxer = new Boxer(athleteName, motivation, numberOfMedals);

                if (gym.GetType().Name != "BoxingGym")
                {
                    return OutputMessages.InappropriateGym;
                }
                gym.AddAthlete(boxer);
            }
            else if (athleteType == "Weightlifter")
            {
                Weightlifter weightlifter = new Weightlifter(athleteName, motivation, numberOfMedals);

                if (gym.GetType().Name != "WeightliftingGym")
                {
                    return OutputMessages.InappropriateGym;
                }
                gym.AddAthlete(weightlifter);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "BoxingGloves")
            {
                equipmentRepository.Add(new BoxingGloves());
            }
            else if(equipmentType == "Kettlebell")
            {
                equipmentRepository.Add(new Kettlebell());
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }


            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);

        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == "BoxingGym")
            {
                gyms.Add(new BoxingGym(gymName));
            }
            else if (gymType == "WeightliftingGym")
            {
                gyms.Add(new WeightliftingGym(gymName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            return String.Format(OutputMessages.SuccessfullyAdded,gymType);

        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.FirstOrDefault(n => n.Name == gymName);

            var equipmentTotalWeight = gym.Equipment.Select(x => x.Weight).Sum();

            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, equipmentTotalWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            Equipment equipment = (Equipment)equipmentRepository.FindByType(equipmentType);

            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            var searchedGym = gyms.FirstOrDefault(g => g.Name == gymName);
            searchedGym.AddEquipment(equipment);
            equipmentRepository.Remove(equipment);


            return String.Format(OutputMessages.EntityAddedToGym, equipmentType,gymName);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            foreach (var gym in gyms)
            {
                result.AppendLine(gym.GymInfo());
            }

            return result.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.FirstOrDefault(n => n.Name == gymName);

            foreach (var athlete in gym.Athletes)
            {
                athlete.Exercise();
            }

            return String.Format(OutputMessages.AthleteExercise, gym.Athletes.Count());
        }
    }
}
