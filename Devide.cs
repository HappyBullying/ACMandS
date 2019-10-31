
namespace ACMandS
{
    partial class ASM_Executor
    {
        private void Devide(string fullstring, string retString, string[] operands)
        {
            int firstSpace = fullstring.IndexOf(' ');
            for (int i = 0; i < firstSpace; i++)
            {
                retString += fullstring[i];
            }
            firstSpace++;
            string ops = fullstring.Substring(firstSpace);
            string[] tmp = ops.Split(", ");
        }
    }
}
