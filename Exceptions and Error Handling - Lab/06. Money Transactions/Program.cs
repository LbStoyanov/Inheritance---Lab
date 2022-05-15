using System;
using System.Collections.Generic;

namespace _06._Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            var accountsInformation = new Dictionary<int, double>();

            for (int i = 0; i < input.Length; i++)
            {
                string[] currentAccountInfo = input[i].Split("-");
                int currentAccountNum = int.Parse(currentAccountInfo[0]);
                double currentAccountBalance = double.Parse(currentAccountInfo[1]);

                accountsInformation.Add(currentAccountNum,currentAccountBalance);
            }

            string commands;

            while ((commands = Console.ReadLine()) != "End")
            {
                
                try
                {
                    string[] actions = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string mainActions = actions[0];

                    int accountNumber = int.Parse(actions[1]);

                    double amount = double.Parse(actions[2]);

                    if (mainActions == "Deposit")
                    {
                        if (!accountsInformation.ContainsKey(accountNumber))
                        {
                            throw new ArgumentException("Invalid account!");
                        }
                        accountsInformation[accountNumber] += amount;
                    }
                    else if (mainActions == "Withdraw")
                    {
                        if (accountsInformation[accountNumber] < amount)
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }

                        accountsInformation[accountNumber] -= amount;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                    double currentAccountBalance = accountsInformation[accountNumber];

                    Console.WriteLine($"Account {accountNumber} has new balance: {currentAccountBalance:f2}");
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Enter another command");
            }
        }
    }
}
