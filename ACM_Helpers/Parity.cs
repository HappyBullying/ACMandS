using System;

namespace ACMandS.ACM_Helpers
{
    partial class ASM_Executor
    {
        private void CheckParity(int numb)
        {
            string binNumb = Convert.ToString(numb, 2);

            while (binNumb.Length < 8)
                binNumb = binNumb.Insert(0, "0");
            
            if (binNumb.Length > 8)
                binNumb = binNumb.Remove(0, binNumb.Length - 8);

            int oneCount = 0;
            foreach(char letter in binNumb)
            {
                if (letter.Equals('1'))
                    oneCount++;
            }
            if (oneCount % 2 == 0)
                pf = 1;
            else
                pf = 0;
        }
    }
}
