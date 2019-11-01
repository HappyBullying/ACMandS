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

                if (COMMANDS[i][0] == ' ')
                {
                    int last = 0;
                    while (COMMANDS[i][last] == ' ')
                    {
                        last++;
                    }
                    COMMANDS[i] = COMMANDS[i].Remove(0, last);
                }
                

                //bool cond1 = char.IsDigit(COMMANDS[i][COMMANDS[i].Length - 2]);
                //bool cond2 = char.IsLetter(COMMANDS[i][COMMANDS[i].Length - 1]);
                //if (cond1 && cond2)
                //{
                //    int index = 0;
                //    string newStr = COMMANDS[i];
                //    for (int j = 0; j < newStr.Length - 1; j++)
                //    {
                //        if (char.IsDigit(newStr[j]) && char.IsLetter(newStr[j + 1]))
                //        {
                //            index = j + 1;
                //        }
                //    }
                //    COMMANDS[i].Remove(index, 1);
                //}
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
