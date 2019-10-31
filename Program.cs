using System;

namespace ACMandS
{
    class Program
    {

        static unsafe void Main(string[] args)
        {
            ASM_Executor asm = new ASM_Executor();
            asm.Run();
        }
    }
}
