using System;
using System.Collections.Generic;
using System.IO;


namespace ACMandS.ACM_Helpers
{
    partial class ASM_Executor
    {
        private string[] COMMANDS = new string[0];
        private Stack<int> STACK = new Stack<int>();
        private Dictionary<string, int> LABELS = new Dictionary<string, int>();
        private int[] MEMORY;
        private int eax, ebx, ecx, edx, esi, edi;
        private int zf, cf, sf, of;
        private LinkedList<string> EXECUTED = new LinkedList<string>();


        public ASM_Executor(string pathToFile)
        {
            eax = 0;
            ebx = 0;
            ecx = 0;
            edx = 0;
            zf = 0;
            cf = 0;
            sf = 0;
            of = 0;
            MEMORY = new int[65536];
            for (int i = 0; i < MEMORY.Length; i++)
                MEMORY[i] = 0;


            ReadCommands(pathToFile);
            DeleteFirstSpace();
            DefineLabels();

        }


        public void Run()
        {
            int index = 0;
            if (COMMANDS[0].ToLower().Contains("start"))
                index += 1;

            //while(index != int.MinValue && EXECUTED.Count < 300)
            //{
            //    index = Handle(index);
            //}

            while(index != int.MinValue)
            {
                index = Handle(index);
            }

            for (int i = 1; i < MEMORY[0] + 1; i++)
                Console.WriteLine(MEMORY[i]);

            StreamWriter wr = new StreamWriter(@"G:/GitRepos/ACMandS/out.txt", false);
            foreach (var elen in EXECUTED)
                wr.WriteLine(elen);
            wr.Close();
        }
        private string prev;
        private int Handle(int index)
        {
            int next = index + 1;
            if (index == COMMANDS.Length)
                return int.MinValue;

            string cm = COMMANDS[index];
            LogCommandAndState(cm);
            string command = "";
            string[] operands = new string[0];
            Devide(cm, ref command, ref operands);


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
                case "push":
                    {
                        Push(operands);
                        break;
                    }
                case "pop":
                    {
                        Pop(operands);
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
                case "jz":
                    {
                        int _param_next = LABELS[operands[0]];
                        next = Jz(_param_next, next);
                        break;
                    }
                case "not":
                    {
                        Not(operands);
                        break;
                    }
                case "nop":
                    {
                        break;
                    }
                case "":
                    {
                        return int.MinValue;
                    }
                default:
                    break;
            }
            prev = cm;
            return next;
        }
        

        private void LogCommandAndState(string command)
        {
            Console.Write(EXECUTED.Count + 1);
            Console.WriteLine("********************************");
            Console.WriteLine("command: " + command + " eax: " + eax + " ebx: " + ebx + " ecx: " + ecx + " edx: " + edx);
            Console.WriteLine("esi: " + esi + " edi: " + edi + " zf: " + zf + " cf: " + cf + " sf: " + sf + " of: " + of);
            Console.WriteLine("*********************************");
            Console.WriteLine();
            string text = command;
            text += " eax: " + eax;
            text += " ebx: " + ebx;
            text += " ecx: " + ecx;
            text += " edx: " + edx;
            text += " esi: " + esi;
            text += " edi: " + edi;
            text += " zf: " + zf;
            text += " cf: " + cf;
            text += " sf: " + sf;
            text += " of: " + of;
            EXECUTED.AddLast(text);
        }

        private bool IsNumber(string str)
        {
            int _out;
            return int.TryParse(str, out _out);
        }
    }
}