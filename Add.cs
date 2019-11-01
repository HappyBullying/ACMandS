
namespace ACMandS
{
    partial class ASM_Executor
    {
        private unsafe void Add(string[] operands)
        {
            if (operands.Length == 0)
            {
                int second = STACK.Pop();
                int first = STACK.Pop();
                STACK.Push(first + second);
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
                    GetPointer(operands[0], ref tmp);
                    first = *tmp;
                }
                eax += first;
                return;
            }

            if (operands.Length == 2)
            {
                int* first = null;
                GetPointer(operands[0], ref first);

                if (IsNumber(operands[1]))
                {
                    *first += int.Parse(operands[1]);
                }
                else
                {
                    int* second = null;
                    GetPointer(operands[1], ref second);
                    *first += (*second);
                }
                return;
            }

            if (operands.Length == 3)
            {
                int* first = null;
                GetPointer(operands[0], ref first);
                int tmp = 0;
                if (IsNumber(operands[1]))
                {
                    *first = *first + int.Parse(operands[1]);
                }
                else
                {
                    int* second = null;
                    GetPointer(operands[1], ref second);
                    tmp = (*first) + (*second);
                }

                int* third = null;
                GetPointer(operands[2], ref third);
                *third = tmp;
                return;
            }
        }
    }
}
