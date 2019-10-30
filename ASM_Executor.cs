using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ACMandS
{
    class ASM_Executor
    {
        private Dictionary<int, string> commandsDesc = new Dictionary<int, string>();
        Stack<int> stack = new Stack<int>();
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

            foreach(KeyValuePair<int, string> elem in commandsDesc)
            {
                commandsDesc.Add(elem.Key, elem.Value);
            }
        }

        public void Start()
        {
            string cm = commandsDesc[0];
            switch(cm)
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


        private unsafe void GetPointer(string elemName, int* ptr)
        {
            string tmp;
            if (elemName.Contains('['))
            {
                tmp = elemName.Remove('[').Remove(']');
                fixed(int* array = MEMORY)
                ptr = &Memory[Convert.ToInt32(tmp)];
            }
        }

        private void Mov(string cm)
        {
            string[] tmp = cm.Split(' ');
            string first = tmp[1].Remove(tmp[1].Length - 1);
            string second = tmp[2];
            if (first.Contains('['))// If it's memory
            {
                int index;
                first = first.Remove('[').Remove(']');
                index = Convert.ToInt32(first);
                
                if (second.Contains('['))
                {
                    int sindex;
                    second = second.Remove('[').Remove(']');
                    sindex = Convert.ToInt32(second);
                    Memory[index] = Memory[sindex];
                    return;
                }
                if (second.Contains("e"))
                {
                    if (second == "eax")
                        Memory[index] = eax;
                    if (second == "ebx")
                        Memory[index] = ebx;
                    if (second == "ecx")
                        Memory[index] = ecx;
                    if (second == "edx")
                        Memory[index] = edx;
                    return;
                }
                Memory[index] = Convert.ToInt32(second);
                return;
            }
            if (first.Contains('e'))
            {
                if (second.Contains('['))
                {
                    int sindex;
                    second = second.Remove('[').Remove(']');
                    sindex = Convert.ToInt32(second);
                    if (first == "eax")
                        eax = Memory[sindex];
                    if (first == "ebx")
                        ebx = Memory[sindex];
                    if (first == "ecx")
                        ecx = Memory[sindex];
                    if (first == "edx")
                        edx = Memory[sindex];
                    return;
                }
                if (second.Contains("e"))
                {
                    if (first == "eax")
                    {
                        if (second == "eax")
                            eax = eax;
                        if (second == "ebx")
                            eax = ebx;
                        if (second == "ecx")
                            eax = ecx;
                        if (second == "edx")
                            eax = edx;
                        return;
                    }
                    if (first == "ebx")
                    {
                        if (second == "eax")
                            ebx = eax;
                        if (second == "ebx")
                            ebx = ebx;
                        if (second == "ecx")
                            ebx = ecx;
                        if (second == "edx")
                            ebx = edx;
                        return;
                    }
                    if (first == "ecx")
                    {
                        if (second == "eax")
                            ecx = eax;
                        if (second == "ebx")
                            ecx = ebx;
                        if (second == "ecx")
                            ecx = ecx;
                        if (second == "edx")
                            ecx = edx;
                        return;
                    }
                    if (first == "edx")
                    {
                        if (second == "eax")
                            edx = eax;
                        if (second == "ebx")
                            edx = ebx;
                        if (second == "ecx")
                            edx = ecx;
                        if (second == "edx")
                            edx = edx;
                        return;
                    }
                }
                if (first == "eax")
                    eax = Memory[Convert.ToInt32(second)];
                if (first == "ebx")
                    ebx = Memory[Convert.ToInt32(second)];
                if (first == "ecx")
                    ecx = Memory[Convert.ToInt32(second)];
                if (first == "edx")
                    edx = Memory[Convert.ToInt32(second)];
            }
            
            //default
            if (second.Contains('['))
            {
                    int sindex;
                    second = second.Remove('[').Remove(']');
                    sindex = Convert.ToInt32(second);
                    if (first == "eax")
                        Memory[Convert.ToInt32(first)] = Memory[sindex];
                    if (first == "ebx")
                        Memory[Convert.ToInt32(first)] = Memory[sindex];
                    if (first == "ecx")
                        Memory[Convert.ToInt32(first)] = Memory[sindex];
                    if (first == "edx")
                        Memory[Convert.ToInt32(first)] = Memory[sindex];
                    return;
            }
            if (second.Contains("e"))
            {
                    if (second == "eax")
                        Memory[Convert.ToInt32(first)] = eax;
                    if (second == "ebx")
                        Memory[Convert.ToInt32(first)] = ebx;
                    if (second == "ecx")
                        Memory[Convert.ToInt32(first)] = ecx;
                    if (second == "edx")
                        Memory[Convert.ToInt32(first)] = edx;
                    return;
            }
            Memory[Convert.ToInt32(first)] = Memory[Convert.ToInt32(second)];
        }
    }
}