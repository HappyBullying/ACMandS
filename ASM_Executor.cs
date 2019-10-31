using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;


namespace ACMandS
{
    partial class ASM_Executor
    {
        private Dictionary<int, string> commandsDesc = new Dictionary<int, string>();
        Stack<int> STACK = new Stack<int>();
        private int[] MEMORY;

        private int eax, ebx, ecx, edx, esi, edi;
        private int zf, cf;

        public event EventHandler MiandrEventHandler;

        public ASM_Executor()
        {
            eax = 0;
            ebx = 0;
            ecx = 0;
            edx = 0;
            zf = 0;
            cf = 0;
            MEMORY = new int[65536];
            for (int i = 0; i < MEMORY.Length; i++)
                MEMORY[i] = 0;
        }

        public void ReadCommands(string filename)
        {
            string[] tmpStrings = File.ReadAllLines(filename, Encoding.UTF8);

            foreach (KeyValuePair<int, string> elem in commandsDesc)
            {
                commandsDesc.Add(elem.Key, elem.Value);
            }
        }

        public void Start()
        {
            string cm = commandsDesc[0];
            string command = "";
            string[] operands = new string[0];
            Devide(cm, command, operands);
            switch (command)
            {
                case "mov":
                    {
                        Mov(cm);
                        break;
                    }
                case "cmp":
                    {
                        break;
                    }



                default:
                    break;
            }
        }




        private void Jump(int index)
        {

        }

        

        private bool IsNumber(string str)
        {
            int _out;
            return int.TryParse(str, out _out);
        }
    }
}