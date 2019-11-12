
namespace ACMandS.ACM_Helpers
{
    partial class ASM_Executor
    {
        private unsafe void Inc(string[] operands)
        {
            int* op = null;
            GetPointer(operands[0], out op);
            (*op)++;
            if (*op > 0)
            {
                sf = 0;
            }
            else
            {
                sf = 1;
            }
            CheckParity(*op);
        }
    }
}
