using System;
using ACMandS.ACM_Helpers;

namespace ACMandS
{
    class Program
    {

        static unsafe void Main(string[] args)
        {
            ASM_Executor asm = new ASM_Executor("../ACMandS/right_pr2.asm");
            asm.Run();
        }
    }
}
