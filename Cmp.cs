

namespace ACMandS
{
    partial class ASM_Executor
    {
        private unsafe void Cmp(string[] operands)
        {
            int first = 0;
            int second = 0;
            if (operands.Length == 0)
            {
                string strSecond = STACK.Pop();
                string strFirst = STACK.Pop();
            }
        }
    }
}
