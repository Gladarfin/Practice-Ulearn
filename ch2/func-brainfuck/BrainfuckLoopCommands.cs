using System.Collections.Generic;

namespace func.brainfuck
{
    public class BrainfuckLoopCommands
    {
        public static void RegisterTo(IVirtualMachine vm)
        {
            var bracketPairs = FindBracket(vm);
            vm.RegisterCommand('[', b =>
            {
                if (vm.Memory[vm.MemoryPointer] == 0)
                {
                    vm.InstructionPointer = bracketPairs[vm.InstructionPointer];
                }
            });

            vm.RegisterCommand(']', b =>
            {
                if (vm.Memory[vm.MemoryPointer] != 0)
                {
                    vm.InstructionPointer = bracketPairs[vm.InstructionPointer];
                }
            });
        }

        public static Dictionary<int, int> FindBracket(IVirtualMachine vm)
        {
            var bracketPairs = new Dictionary<int, int>();
            var bracketStack = new Stack<int>();
            for (int i = 0; i < vm.Instructions.Length; i++)
            {
                if (vm.Instructions[i] == '[')
                    bracketStack.Push(i);
                if (vm.Instructions[i] == ']')
                {
                    bracketPairs.Add(bracketStack.Peek(), i);
                    bracketPairs.Add(i, bracketStack.Peek());
                    bracketStack.Pop();
                }
            }
            return bracketPairs;
        }
    }
}