﻿namespace ACMandS.ACM_Helpers
{
    partial class ASM_Executor
    {
        private unsafe void Dec(string[] operands)
        {
            int* op = null;
            GetPointer(operands[0], ref op);
            (*op)--;
            if (*op > 0)
            {
                sf = 0;
            }
            else
            {
                sf = 1;
            }
            CheckParity(*op);
        }
    }
}
