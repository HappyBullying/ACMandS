
namespace ACMandS.ACM_Helpers
{
    partial class ASM_Executor
    {
        private int Jmp(int index)
        {
            return index;
        }

        private int Ja(int index, int next)
        {
            if (cf == 0 && zf == 0)
            {
                return index;
            }
            else
            {
                return next;
            }
        }

        private int Jz(int index, int next)
        {
            if (zf == 1)
                return index;
            return next;
        }
        private int Jge(int index, int next)
        {
            if (sf == of)
            {
                return index;
            }
            else
            {
                return next;
            }
        }

        private int Jl(int index, int next)
        {
            if (sf != of)
            {
                return index;
            }
            else
            {
                return next;
            }
        }

        private int Jbe(int index, int next)
        {
            if (cf == 1 && zf == 1)
            {
                return index;
            }
            else
            {
                return next;
            }
        }


    }
}
