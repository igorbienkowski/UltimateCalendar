using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCalendar.Models
{
    class PasswordDecrypter
    {
        private string alphabet = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ0123456789";
        private string decryptedPassword = "";

        public string decryptPassword(string passwordToDecrypt)
        {
            foreach (char @char in passwordToDecrypt)
            {
                if (alphabet.Contains(@char))
                {
                    decryptedPassword += alphabet[minusTen(alphabet.IndexOf(@char))];
                }
                else decryptedPassword += @char;
            }
            return decryptedPassword;
        }

        private int minusTen(int number)
        {
            if (number - 10 < 0)
            {
                return (number - 10) + 62;
            }
            else return number - 10;
        }
    }
}
