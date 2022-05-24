using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string[] requestedFieldsnames = new string[] { "username", "password" };
            string result = 
                spy.StealFieldInfo(investigatedClassName:"Stealer.Hacker",requestedFieldsnames);

            Console.WriteLine(result);
        }
    }
}
