
namespace ACMandS.ACM_Helpers
{
    partial class ASM_Executor
    {
        private void Devide(string fullstring, ref string retString, ref string[] operands)
        {
            int firstSpace = fullstring.IndexOf(' ');
            if (firstSpace == -1)
            {
                retString = fullstring;
                operands = new string[0];
                return;
            }
            retString = "";
            for (int i = 0; i < firstSpace; i++)
            {
                retString += fullstring[i];
            }
            firstSpace++;
            string ops = fullstring.Substring(firstSpace);
            

            operands = ops.Split(", ");
        }
    }
}
