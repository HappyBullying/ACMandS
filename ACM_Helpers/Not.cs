
namespace ACMandS.ACM_Helpers
{
    partial class ASM_Executor
    {
        private unsafe void Not(string[] operands)
        {
            int* operandPtr = null;
            GetPointer(operands[0], ref operandPtr);

            if ((*operandPtr) == 0)
            {
                *operandPtr = 1;
            }
            else
            {
                *operandPtr = 0;
            }
        }
    }
}
