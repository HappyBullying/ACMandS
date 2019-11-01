
namespace ACMandS.ACM_Helpers
{
    partial class ASM_Executor
    {
        private void CheckParity(int numb)
        {
            int count = 0;
            int tmp;
            while (numb != 0)
            {
                tmp = numb;
                numb = numb >> 1;
                
                if (tmp % 2 != numb % 2)
                {
                    count++;
                }
            }
            if (count % 2 == 0)
            {
                pf = 1;
            }
            else
            {
                pf = 0;
            }
        }
    }
}
