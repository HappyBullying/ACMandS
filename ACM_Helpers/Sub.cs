
namespace ACMandS.ACM_Helpers
{
    partial class ASM_Executor
    {
        private unsafe void Sub(string[] operands)
        {
            if (operands.Length == 0)
            {
                int second = STACK.Pop();
                int first = STACK.Pop();
                STACK.Push(second + first);
                if (STACK.Peek() > 0)
                {
                    sf = 0;
                }
                else
                {
                    sf = 1;
                }
                return;
            }

            if (operands.Length == 1)
            {
                int first = 0;

                if (IsNumber(operands[0]))
                {
                    first = int.Parse(operands[0]);
                }
                else
                {
                    int* tmp = null;
                    GetPointer(operands[0], out tmp);
                    first = *tmp;
                }
                eax -= first;
                if (eax > 0)
                {
                    sf = 0;
                }
                else
                {
                    sf = 1;
                }
                return;
            }

            if (operands.Length == 2)
            {
                int* first = null;
                GetPointer(operands[0], out first);

                if (IsNumber(operands[1]))
                {
                    *first -= int.Parse(operands[1]);
                }
                else
                {
                    int* second = null;
                    GetPointer(operands[1], out second);
                    *first -= (*second);
                }
                if (*first > 0)
                {
                    sf = 0;
                }
                else
                {
                    sf = 1;
                }
                return;
            }

            if (operands.Length == 3)
            {
                int* first = null;
                GetPointer(operands[0], out first);
                int tmp = 0;
                if (IsNumber(operands[1]))
                {
                    tmp = *first - int.Parse(operands[1]);
                }
                else
                {
                    int* second = null;
                    GetPointer(operands[1], out second);
                    tmp = (*first) - (*second);
                }

                int* third = null;
                GetPointer(operands[2], out third);
                *third = tmp;
                if (*third > 0)
                {
                    sf = 0;
                }
                else
                {
                    sf = 1;
                }
                return;
            }
        }
    }
}
