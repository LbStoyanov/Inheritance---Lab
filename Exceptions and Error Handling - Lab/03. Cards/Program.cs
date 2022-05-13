using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Cards
{
    public class Card
    {
        private readonly HashSet<string> cardsFaces = new HashSet<string>
        {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "J",
            "Q",
            "K",
            "A"
        };

        private readonly Dictionary<string, char> cardsSuit = new Dictionary<string, char>
        {
            {"S",'\u2660' },
            {"H",'\u2665' },
            {"D",'\u2666' },
            {"C",'\u2663' },
        };

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face { get; set; }
        public string Suit { get; set; }

        public string PrintCard(string face, string suit)
        {
            if (cardsFaces.Contains(face) && cardsSuit.ContainsKey(suit))
            {
                string currentFace = cardsFaces.FirstOrDefault(x => x == face);
                char currentSuit = cardsSuit[suit];

                return $"[{currentFace}{currentSuit}]";
            }
            else
            {
                throw new ArgumentException("Invalid card!");
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = new List<string>();

            string[] cardsInput = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < cardsInput.Length; i++)
            {

                try
                {
                    string[] test = cardsInput[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string face = test[0];
                    string suit = test[1];

                    Card card = new Card(face, suit);
                    var newCard = card.PrintCard(face, suit);
                    cards.Add(newCard);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }
    }
}
