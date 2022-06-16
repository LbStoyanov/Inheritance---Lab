using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        VesselRepository vessels;
        List<Captain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<Captain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (!captains.Any(x => x.FullName == selectedCaptainName))
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            if (!vessels.Models.Any(x => x.Name == selectedVesselName))
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            IVessel searchedVessel = vessels.Models.FirstOrDefault(x => x.Name == selectedVesselName);

            if (searchedVessel.Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            ICaptain captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);

            captain.AddVessel(searchedVessel);
            searchedVessel.Captain = captain;
            

            return String.Format(OutputMessages.SuccessfullyAssignCaptain,selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            if (!vessels.Models.Any(x => x.Name == attackingVesselName))
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            if (!vessels.Models.Any(x => x.Name == defendingVesselName))
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            var attackinVessel = vessels.Models.FirstOrDefault(x => x.Name == attackingVesselName);
            var defendingVessel = vessels.Models.FirstOrDefault(x => x.Name == defendingVesselName);

            if (attackinVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }

            if (defendingVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attackinVessel.Attack(defendingVessel);
            attackinVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            double defendingVesselCurrentArmorTickness = defendingVessel.ArmorThickness;

            //return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName,attackinVessel, defendingVesselCurrentArmorTickness);
            return String.Format($"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defendingVesselCurrentArmorTickness}.");
        }

        public string CaptainReport(string captainFullName)
        {

            Captain captain = (Captain)captains.FirstOrDefault(x => x.FullName == captainFullName);

            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            if (captains.Any(x => x.FullName == fullName))
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            Captain captain = new Captain(fullName);
            captains.Add(captain);

            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vesselType != "Submarine" && vesselType != "Battleship")
            {
                return String.Format(OutputMessages.InvalidVesselType, vesselType);
            }

            if (vessels.Models.Any(x => x.Name == name))
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType,name);
            }

            IVessel vessel = null;

            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }

            if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }

            vessels.Add(vessel);

            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType,name,mainWeaponCaliber,speed);

        }

        public string ServiceVessel(string vesselName)
        {
            if (vessels.Models.Any(x => x.Name == vesselName))
            {
                IVessel vessel = vessels.Models.FirstOrDefault(x => x.Name == vesselName);
                vessel.RepairVessel();
                return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);

            }

            return String.Format(OutputMessages.VesselNotFound, vesselName);

        }

        public string ToggleSpecialMode(string vesselName)
        {
            if (vessels.Models.Any(x => x.Name == vesselName))
            {
                IVessel vessel = vessels.Models.FirstOrDefault(x => x.Name == vesselName);

                if (vessel.GetType().Name == "Submarine")
                {
                    Submarine submarine = vessel as Submarine;
                    submarine.ToggleSubmergeMode();
                    return String.Format(OutputMessages.ToggleSubmarineSubmergeMode,vesselName);
                    
                }

                if (vessel.GetType().Name == "Battleship")
                {
                    Battleship battleship = vessel as Battleship;
                    battleship.ToggleSonarMode();
                    return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
                }
            }
            

            return String.Format(OutputMessages.VesselNotFound, vesselName);
        }

        public string VesselReport(string vesselName)
        {
            Vessel vessel = (Vessel)vessels.Models.FirstOrDefault(x => x.Name == vesselName);

            return vessel.ToString();
        }
    }
}
