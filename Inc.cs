
namespace ACMandS
{
    partial class ASM_Executor
    {
        public unsafe void Inc(string[] operands)
        {
            int* op = null;
            GetPointer(operands[0], op);
            (*op)++;
        }
    }
}
