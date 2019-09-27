using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Regex regex = new Regex(@"^((?:(?:[a-zA-Z0-9_\-\.]+)@(?:(?:\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(?:(?:[a-zA-Z0-9\-]+\.)+))(?:[a-zA-Z]{2,4}|[0-9]{1,3})(?:\]?)(?:\s*;\s*|\s*$))*)$");
                string text = Console.ReadLine();
                Match match = regex.Match(text);
                if (match.Success)                
                    Console.WriteLine("OK");                     
                else
                    Console.WriteLine("Błąd");
            }
        }
    }
}
