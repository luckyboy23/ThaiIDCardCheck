using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ThaiIDCardCheck
{
    public class ThaiIdCard
    {
        public static void IsThaiId(string id)
        {
            bool result = false;
            Console.Write($"{id} => ");
            Regex rexPersonal = new Regex(@"^[0-9]{13}$");
            if (rexPersonal.IsMatch(id))
            { 
                int sum = 0;
                for(int i = 0;i < 12; i++)
                {
                    sum += Convert.ToInt32(id[i].ToString()) * (13 - i);
                }
                int checkdigit = ((11 - (sum % 11)) % 10);
                result = Convert.ToInt32(id[12].ToString()) == checkdigit;
            }

            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("valid");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("invalid");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
