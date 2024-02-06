using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJS5_CSharp.Sources
{
    public class Utils
    {
        public static int GetInt()
        {
            int iInt;
            iInt = Console.ReadKey().KeyChar - '0';
            Console.WriteLine(iInt);
            return iInt;
        }
    }
}
