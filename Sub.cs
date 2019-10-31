
namespace ACMandS
{
    partial class ASM_Executor
    {
        private unsafe void Sub(string[] operands)
        {
            if (operands.Length == 0)
            {
                int second = STACK.Pop();
                int first = STACK.Pop();
                int* ptrSecond = null;
                int* ptrFirst = null;
                /*I dont know what is inside stack*/
                int? firstVal = null;
                int? secondVal = null;
                /*********************************/

                if (!IsNumber(second))
                    GetPointer(second, ptrSecond);
                else
                {
                    secondVal = int.Parse(second);
                }

                if (!IsNumber(first))
                    GetPointer(first, ptrFirst);
                else
                {
                    firstVal = int.Parse(first);
                }
                int firstFinal = 0;
                int secondFinal = 0;


                if (firstVal == null)
                {
                    firstFinal = *ptrFirst;
                }
                else
                {
                    firstFinal = firstVal.Value;
                }


                if (secondVal == null)
                {
                    secondFinal = *ptrSecond;
                }
                else
                {
                    secondFinal = secondVal.Value;
                }
                STACK.Push((firstFinal - secondFinal).ToString());
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
                    GetPointer(operands[0], tmp);
                    first = *tmp;
                }
                eax -= first;
                return;
            }

            if (operands.Length == 2)
            {
                int* first = null;
                GetPointer(operands[0], first);

                if (IsNumber(operands[1]))
                {
                    *first -= int.Parse(operands[1]);
                }
                else
                {
                    int* second = null;
                    GetPointer(operands[1], second);
                    *first -= (*second);
                }
                return;
            }

            if (operands.Length == 3)
            {
                int* first = null;
                GetPointer(operands[0], first);
                int tmp = 0;
                if (IsNumber(operands[1]))
                {
                    *first = *first - int.Parse(operands[1]);
                }
                else
                {
                    int* second = null;
                    GetPointer(operands[1], second);
                    tmp = (*first) - (*second);
                }

                int* third = null;
                GetPointer(operands[2], third);
                *third = tmp;
                return;
            }
        }
    }
}
