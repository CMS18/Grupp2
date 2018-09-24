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
            Console.Write("Enter input: ");
            var text = Console.ReadLine().UppercaseWordFirstLetter();

            Console.WriteLine(text);
        }
    }
}
