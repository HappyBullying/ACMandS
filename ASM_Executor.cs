using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;


namespace ACMandS
{
    partial class ASM_Executor
    {
        private string[] COMMANDS = new string[0];
        private Stack<int> STACK = new Stack<int>();
        private Dictionary<string, int> LABELS = new Dictionary<string, int>();
        private int[] MEMORY;

        private int eax, ebx, ecx, edx, esi, edi;
        private int zf, cf, sf, of;

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

            ReadCommands(@"G:/GitRepos/ACMandS/right_pr2.asm");
            
            DeleteFirstSpace();
            DefineLabels();

            Run();
        }


        public void Run()
        {
            int index = 0;
            if (COMMANDS[0].ToLower().Contains("start"))
                index += 1;

            while(index != int.MinValue)
            {
                index = Handle(index);
            }
        }

        private int Handle(int index)
        {
            int next = index + 1;

            string cm = COMMANDS[0];
            string command = "";
            string[] operands = new string[0];
            Devide(cm, command, operands);


            switch (command)
            {
                case "mov":
                    {
                        Mov(operands);
                        break;
                    }
                case "cmp":
                    {
                        Cmp(operands);
                        break;
                    }
                case "add":
                    {
                        Add(operands);
                        break;
                    }
                case "sub":
                    {
                        Sub(operands);
                        break;
                    }
                case "inc":
                    {
                        Inc(operands);
                        break;
                    }
                case "dec":
                    {
                        Dec(operands);
                        break;
                    }
                case "jmp":
                    {
                        next = Jmp(LABELS[operands[0]]);
                        break;
                    }
                case "ja":
                    {
                        int _param_next = LABELS[operands[0]];
                        next = Ja(_param_next, next);
                        break;
                    }
                case "jge":
                    {
                        int _param_next = LABELS[operands[0]];
                        next = Jge(_param_next, next);
                        break;
                    }
                case "jl":
                    {
                        int _param_next = LABELS[operands[0]];
                        next = Jl(_param_next, next);
                        break;
                    }
                case "jbe":
                    {
                        int _param_next = LABELS[operands[0]];
                        next = Jbe(_param_next, next);
                        break;
                    }
                case "nop":
                    {
                        next = int.MinValue;
                        break;
                    }
                default:
                    break;
            }
            return next;
        }
        

        private bool IsNumber(string str)
        {
            int _out;
            return int.TryParse(str, out _out);
        }
    }
}