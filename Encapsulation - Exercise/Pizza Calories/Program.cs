using System;

namespace EncapsulationExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string type = input[0];
            string flourType = input[1];
            string backingTecknique = input[2];
            int weight = int.Parse(input[3]);

            Dough dough = new Dough(flourType,backingTecknique,weight);
        }
    }
}
