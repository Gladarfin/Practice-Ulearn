using System;
using System.Collections.Generic;

namespace func.brainfuck
{
    public class VirtualMachine : IVirtualMachine
    {
        Dictionary<char, Action<IVirtualMachine>> registerCommand =
        new Dictionary<char, Action<IVirtualMachine>>();

        public VirtualMachine(string program, int memorySize)
        {
            Instructions = program;
            Memory = new byte[memorySize];
        }

        public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
        {
            registerCommand.Add(symbol, execute);
        }

        public string Instructions { get; }
        public int InstructionPointer { get; set; }
        public byte[] Memory { get; }
        public int MemoryPointer { get; set; }

        public void Run()
        {
            for (InstructionPointer = 0; InstructionPointer < Instructions.Length; InstructionPointer++)
            {
                var command = Instructions[InstructionPointer];
                if (registerCommand.ContainsKey(command))
                {
                    registerCommand[command](this);
                }
            }
        }
    }
}