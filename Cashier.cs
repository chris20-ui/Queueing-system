using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueingSystem
{
    using System.Collections.Generic;

    namespace QueueingSystem
    {
        public class Cashier
        {
            private int x;
            public static string CurrentNumber = "";
            public static Queue<string> CashierQueue;

            public Cashier()
            {
                x = 10000;
                CashierQueue = new Queue<string>();
            }

            public string GenerateNumber(string prefix)
            {
                x++;
                return prefix + x.ToString();
            }
        }
    }
}