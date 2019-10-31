using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACMandS
{
    partial class ASM_Executor
    {
        private void DeleteFirstSpace()
        {
            for (int i = 0; i < COMMANDS.Length; i++)
            {
                if (COMMANDS[i].IndexOf('\t') == 0)
                {
                    COMMANDS[i] = COMMANDS[i].Replace("\t", string.Empty);
                    continue;
                }

                if (COMMANDS[i][0] == ' ')
                {
                    int last = 0;
                    while(COMMANDS[i][last] == ' ')
                    {
                        last++;
                    }
                    COMMANDS[i] = COMMANDS[i].Remove(0, last);
                }
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
