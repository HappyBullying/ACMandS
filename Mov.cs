
namespace ACMandS
{
    partial class ASM_Executor
    {
        private unsafe void Mov(string[] operands)
        {
            int* first = null;
            int* second = null;
            GetPointer(operands[0], first);
            GetPointer(operands[1], second);
            (*first) = (*second);
        }
    }
}
