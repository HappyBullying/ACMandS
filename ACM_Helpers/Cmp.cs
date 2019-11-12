

namespace ACMandS.ACM_Helpers
{
    partial class ASM_Executor
    {
        private unsafe void Cmp(string[] operands)
        {
            int first = 0;
            int second = 0;
            if (operands.Length == 0)
            {
                second = STACK.Pop();
                first = STACK.Pop();
            }
            if (operands.Length == 1)
            {
                first = eax;
                if (IsNumber(operands[0]))
                {
                    second = int.Parse(operands[0]);
                }
                else
                {
                    int* tmpS = null;
                    GetPointer(operands[0], out tmpS);
                    second = *tmpS;
                }
            }


            if (operands.Length == 2)
            {
                if (IsNumber(operands[0]))
                {
                    first = int.Parse(operands[0]);
                }
                else
                {
                    int* tmpF = null;
                    GetPointer(operands[0], out tmpF);
                    first = *tmpF;
                }


                if (IsNumber(operands[1]))
                {
                    second = int.Parse(operands[1]);
                }
                else
                {
                    int* tmpS = null;
                    GetPointer(operands[1], out tmpS);
                    second = *tmpS;
                }
            }


            //JA
            if (first > second)
            {
                cf = 0;
                zf = 0;
                return;
            }


            //JBE
            if (first <= second)
            {
                cf = 1;
                zf = 1;
                return;
            }
        }
    }
}
