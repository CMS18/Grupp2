using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LINQ_Instuderingsuppgifter.Extensions;

namespace LINQ_Instuderingsuppgifter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter input: ");
            //var text = Console.ReadLine().UppercaseWordFirstLetter();

            //Console.WriteLine(text);

            //DateTime date = new DateTime(2018,2,24);
            //Console.WriteLine(date.GetLastDateOfMonth());

            //List<string> strings = new List<string>();
            //strings.Add("STRING 1");
            //strings.Add("STRING 2");
            //strings.Add("STRING 3");
            //strings.Add("STRING 4");

            //Console.WriteLine(strings.ListToString());

            List<int> tal = new List<int>();
            tal.Add(7, 8, 9, 10, 15, 27, 35, 90);
            foreach(int t in tal)
                Console.WriteLine(t);
        }
    }
}
