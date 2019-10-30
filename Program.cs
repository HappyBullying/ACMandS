using System;

namespace ACMandS
{
    class Program
    {

        static unsafe void Main(string[] args)
        {
            int[] t = { 1, 2, 4};
            int* y = &t[1];
            Console.WriteLine(*y);
        }
    }
}
