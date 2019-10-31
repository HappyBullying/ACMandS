

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
                second = STACK.Pop();
                first = STACK.Pop();
            }
            else
            {
                if (IsNumber(operands[0]))
                {
                    first = int.Parse(operands[0]);
                }
                else
                {
                    int* tmpF = null;
                    GetPointer(operands[0], tmpF);
                    first = *tmpF;
                }


                if (IsNumber(operands[1]))
                {
                    second = int.Parse(operands[1]);
                }
                else
                {
                    int* tmpS = null;
                    GetPointer(operands[1], tmpS);
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

            //JGE
            if (first >= second)
            {
                sf = of;
                return;
            }

            //JL
            if (first < second)
            {
                sf = of + 1;
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
