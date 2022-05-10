using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class StationaryPhone : ICallable
    {
        public string Calling(string phoneNumber)
        {
            if (IsValidNumber(phoneNumber))
            {
                return $"Dialing... {phoneNumber}";
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
    }
}
