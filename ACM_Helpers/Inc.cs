
namespace ACMandS.ACM_Helpers
{
    partial class ASM_Executor
    {
        private unsafe void Inc(string[] operands)
        {
            int* op = null;
            GetPointer(operands[0], ref op);
            (*op)++;
        }
    }
}
