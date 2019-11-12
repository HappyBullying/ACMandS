
namespace ACMandS.ACM_Helpers
{
    partial class ASM_Executor
    {
        private unsafe void Mov(string[] operands)
        {
            int* first = null;
            int* second = null;
            GetPointer(operands[0], out first);
            GetPointer(operands[1], out second);

            int tmp;
            if (!int.TryParse(operands[1], out tmp))
                (*first) = (*second);
            else
                (*first) = tmp;
        }
    }
}
