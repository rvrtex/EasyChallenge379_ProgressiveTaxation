using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyChallenge379_ProgressiveTaxation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            while(input != "exit")
            {
                Console.WriteLine("please enter your income to calculate taxes owed. Type exit to Exit.");
                input = Console.ReadLine();
                int n;
                if(int.TryParse(input,out n))
                {
                    var taxProgam = new FindTaxesOwed();
                    var output = taxProgam.findTaxesOwed(n);
                    Console.WriteLine("You owe: {0}",output);

                }

            }

           
        }

        
    }
}