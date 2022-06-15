using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> heroes)
        {

            var knights = heroes.OfType<Knight>();
            var barbarians = heroes.OfType<Barbarian>();

            while (true)
            {
                var aliveKnights = knights.Where(x => x.IsAlive && x.Weapon != null);
                var aliveBarbarians = barbarians.Where(x => x.IsAlive && x.Weapon != null);

                foreach (var knight in aliveKnights)
                {
                    foreach (var barbarian in aliveBarbarians)
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }

                aliveBarbarians = barbarians.Where(x => x.IsAlive);

                if (aliveBarbarians.Any(x => x.IsAlive))
                {
                    foreach (var barbarian in aliveBarbarians)
                    {
                        foreach (var knight in aliveKnights)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                }

                aliveKnights = knights.Where(x => x.IsAlive);
                aliveBarbarians = barbarians.Where(x => x.IsAlive);

                if (aliveKnights.Count() == 0)
                {
                    int deadBarbarians = barbarians.Where(b => !b.IsAlive).Count();

                    return $"The barbarians took {deadBarbarians} casualties but won the battle.";
                }

                if (aliveBarbarians.Count() == 0)
                {
                    int deadKnights = knights.Where(k => !k.IsAlive).Count();

                    return $"The knights took {deadKnights} casualties but won the battle.";
                }
            }
        }
    }
}
