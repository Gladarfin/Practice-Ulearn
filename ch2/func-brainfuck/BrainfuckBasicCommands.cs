using System;

namespace func.brainfuck
{
    public class BrainfuckBasicCommands
    {
        public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
        {
            vm.RegisterCommand('.', b => write((char)b.Memory[b.MemoryPointer]));
            vm.RegisterCommand('+', b => VMIncrement(b));
            vm.RegisterCommand('-', b => VMDecrement(b));
            vm.RegisterCommand(',', b => b.Memory[b.MemoryPointer] = (byte)read());
            vm.RegisterCommand('>', b => MoveToNext(b));
            vm.RegisterCommand('<', b => MoveToPrev(b));
            Constant.WriteAllSymbols(vm);
        }

        private static void VMIncrement(IVirtualMachine machine)
        {
            if (machine.Memory[machine.MemoryPointer] != 255)
                machine.Memory[machine.MemoryPointer]++;
            else
                machine.Memory[machine.MemoryPointer] = 0;
        }

        private static void VMDecrement(IVirtualMachine machine)
        {
            if (machine.Memory[machine.MemoryPointer] != 0)
                machine.Memory[machine.MemoryPointer]--;
            else
                machine.Memory[machine.MemoryPointer] = 255;
        }

        private static void MoveToNext(IVirtualMachine machine)
        {
            machine.MemoryPointer = (machine.MemoryPointer == machine.Memory.Length - 1) ?
                0 : machine.MemoryPointer + 1;
        }

        private static void MoveToPrev(IVirtualMachine machine)
        {
            machine.MemoryPointer = (machine.MemoryPointer == 0) ?
                machine.Memory.Length - 1 : machine.MemoryPointer - 1;
        }
    }

    public class Constant
    {
        static readonly char[] allSymbols =
            "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890".ToCharArray();
        public static void WriteAllSymbols(IVirtualMachine vm)
        {
            foreach (var symbol in allSymbols)
                vm.RegisterCommand(symbol, machine => machine.Memory[machine.MemoryPointer] = (byte)symbol);
        }
    }
}