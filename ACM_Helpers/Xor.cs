

namespace ACMandS.ACM_Helpers
{
    partial class ASM_Executor
    {
        public unsafe void Xor(string[] operands)
        {
            if (operands.Length == 0)
            {
                int first = STACK.Pop();
                int second = STACK.Pop();
                first = first ^ second;
                CheckParity(first);
                if (first > 0)
                {
                    sf = 0;
                }
                else
                {
                    sf = 1;
                }
                if (first == 0)
                    zf = 0;
                cf = 0;
                of = 0;
                STACK.Push(first);
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
                eax = eax ^ first;
                CheckParity(eax);
                if (eax > 0)
                {
                    sf = 0;
                }
                else
                {
                    sf = 1;
                }
                if (eax == 0)
                    zf = 0;
                cf = 0;
                of = 0;
                return;
            }

            if (operands.Length == 2)
            {
                int* first = null;
                GetPointer(operands[0], out first);

                if (IsNumber(operands[1]))
                {
                    *first = (*first) ^ int.Parse(operands[1]);
                }
                else
                {
                    int* second = null;
                    GetPointer(operands[1], out second);
                    *first = (*first) ^ (*second);
                }

                CheckParity(*first);
                if (*first > 0)
                {
                    sf = 0;
                }
                else
                {
                    sf = 1;
                }
                if (*first == 0)
                    zf = 0;
                cf = 0;
                of = 0;
                return;
            }

            if (operands.Length == 3)
            {
                int* first = null;
                GetPointer(operands[0], out first);
                int tmp = 0;
                if (IsNumber(operands[1]))
                {
                    tmp = (*first) ^ int.Parse(operands[1]);
                }
                else
                {
                    int* second = null;
                    GetPointer(operands[1], out second);
                    tmp = (*first) ^ (*second);
                }

                int* third = null;
                GetPointer(operands[2], out third);
                *third = tmp;


                CheckParity(tmp);
                if (tmp > 0)
                {
                    sf = 0;
                }
                else
                {
                    sf = 1;
                }
                if (tmp == 0)
                    zf = 0;
                cf = 0;
                of = 0;
                return;
            }
        }
    }
}
