using System;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string phoneInput = Console.ReadLine();
            string websiteInput = Console.ReadLine();

            string[] phoneNumbers = phoneInput.Split(" ",StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartphone = new Smartphone();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                var currentPhoneNumber = phoneNumbers[i];
                if (currentPhoneNumber.Length == 10)
                {
                    
                    Console.WriteLine(smartphone.Calling(currentPhoneNumber));
                }
                else
                {
                    StationaryPhone stationaryPhone = new StationaryPhone();
                    Console.WriteLine(stationaryPhone.Calling(currentPhoneNumber));
                }
            }


            string[] websites = websiteInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < websites.Length; i++)
            {
                var currentWebSite = websites[i];
                Console.WriteLine(smartphone.Browsing(currentWebSite));
            }

        }
        

       
    }
}
