
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACMandS.ACM_Helpers
{
    partial class ASM_Executor
    {
        private void DeleteFirstSpace()
        {
            for (int i = 0; i < COMMANDS.Length; i++)
            {
                // Remove comments
                int commentIndex = COMMANDS[i].IndexOf(';');
                if (commentIndex != -1)
                {
                    COMMANDS[i] = COMMANDS[i].Remove(commentIndex);
                }
                // remove decimal description
                if (char.IsDigit(COMMANDS[i][COMMANDS[i].Length - 2]) && COMMANDS[i][COMMANDS[i].Length - 1] == 'd')
                    COMMANDS[i] = COMMANDS[i].Remove(COMMANDS[i].Length - 1);
                COMMANDS[i] = COMMANDS[i].Replace("d,", ",");
                COMMANDS[i] = COMMANDS[i].Replace("d]", "]");
                if (COMMANDS[i][COMMANDS[i].Length - 1] == 'd' && char.IsDigit(COMMANDS[i][COMMANDS[i].Length - 2]))
                {
                    COMMANDS[i] = COMMANDS[i].Replace(COMMANDS[i].Last().ToString(), "");
                }
                if (COMMANDS[i].IndexOf('\t') == 0)
                {
                    COMMANDS[i] = COMMANDS[i].Replace("\t", string.Empty);
                    continue;
                }

                // remove space
                if (COMMANDS[i][0] == ' ')
                {
                    int last = 0;
                    while (COMMANDS[i][last] == ' ')
                    {
                        last++;
                    }
                    COMMANDS[i] = COMMANDS[i].Remove(0, last);
                }
                COMMANDS[i] = COMMANDS[i].Replace("\t", "");
            }
        }

        private void DefineLabels()
        {
            for (int i = 0; i < COMMANDS.Length; i++)
            {
                if (COMMANDS[i].Contains(':'))
                {
                    LABELS.Add(COMMANDS[i].Replace(":",""), i + 1);
                }
            }
        }

        private void ReadCommands(string filename)
        {
            List<string> tmp = File.ReadAllLines(filename, Encoding.UTF8).ToList();
            tmp.RemoveAll(predicate => predicate.Equals(string.Empty));
            COMMANDS = tmp.ToArray();
        }
    }
}
