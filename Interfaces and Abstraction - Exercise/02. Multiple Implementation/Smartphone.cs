using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Smartphone : ICallable
    {
        //private string phoneNumber;
        //public Smartphone(string phoneNumber)
        //{
        //    this.phoneNumber = phoneNumber;
        //}


        public string Browsing(string website)
        {
            if (IsValidWebsite(website))
            {
                return $"Browsing: {website}!";
            }

            return "Invalid URL!";
        }

        public string Calling(string phoneNumber)
        {
            if (IsValidNumber(phoneNumber))
            {
                return $"Calling... {phoneNumber}";
            }

            return "Invalid number!";
        }

        private bool IsValidNumber(string phoneInput)
        {
            for (int i = 0; i < phoneInput.Length; i++)
            {
                if (!char.IsDigit(phoneInput[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsValidWebsite(string websiteInput)
        {
            for (int i = 0; i < websiteInput.Length; i++)
            {
                if (char.IsDigit(websiteInput[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
