using System;

namespace ACMandS.ACM_Helpers
{
    partial class ASM_Executor
    {
        private unsafe void GetPointer(string elemName, ref int* ptr)
        {
            string tmp;
            if (elemName.Contains('['))
            {
                tmp = elemName.Replace("[", "").Replace("]", "");

                int parsedNum;
                bool isNum = int.TryParse(tmp, out parsedNum);


                if (!isNum)
                {
                    GetPointer(tmp, ref ptr);
                    parsedNum = *ptr;
                }
                fixed (int* array = MEMORY)
                {
                    ptr = array + parsedNum;
                }
                return;
            }

            if (elemName.Length == 3 && elemName[0] == 'e')
            {
                switch (elemName)
                {
                    case "eax":
                        {
                            fixed (int* tmpPtr = &eax)
                            {
                                ptr = tmpPtr;
                            }
                            break;
                        }
                    case "ebx":
                        {
                            fixed (int* tmpPtr = &ebx)
                            {
                                ptr = tmpPtr;
                            }
                            break;
                        }
                    case "ecx":
                        {
                            fixed (int* tmpPtr = &ecx)
                            {
                                ptr = tmpPtr;
                            }
                            break;
                        }
                    case "edx":
                        {
                            fixed (int* tmpPtr = &edx)
                            {
                                ptr = tmpPtr;
                            }
                            break;
                        }
                    case "esi":
                        {
                            fixed (int* tmpPtr = &esi)
                            {
                                ptr = tmpPtr;
                            }
                            break;
                        }
                    case "edi":
                        {
                            fixed (int* tmpPtr = &edi)
                            {
                                ptr = tmpPtr;
                            }
                            break;
                        }
                    default:
                        break;
                }
                return;
            }
        }
    }
}
