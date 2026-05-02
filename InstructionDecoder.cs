using Vm.Instruction;

namespace Vm;

public static class InstructionDecoder
{
    public static IInstruction Decode(Memory memory, ref uint IP)
    {
        byte opcode = memory[IP];
        IP += 1;

        // [OP][R][I]
        if (opcode == LoadImmediateInstruction.Opcode)
        {
            byte register = memory.ReadWord8(IP);
            IP += 1;
            int immediate = memory.ReadWord32(IP);
            IP += 4;

            return new LoadImmediateInstruction((Register)register, immediate);
        }

        // [OP][R][A]
        if (opcode == LoadMemoryInstruction.Opcode)
        {
            byte register = memory.ReadWord8(IP);
            IP += 1;
            int address = memory.ReadWord32(IP);

            if (address < 0)
            {
                throw new Exception($"Memory address at {IP} cannot have a negative values.");
            }

            IP += 4;

            return new LoadMemoryInstruction((Register)register, (uint)address);
        }

        // [OP][R][R][R]
        if (opcode == AddInstruction.Opcode)
        {
            byte register1 = memory.ReadWord8(IP);
            IP += 1;
            byte register2 = memory.ReadWord8(IP);
            IP += 1;
            byte register3 = memory.ReadWord8(IP);
            IP += 1;

            return new AddInstruction((Register)register1, (Register)register2, (Register)register3);
        }

        // [OP][R][R][R]
        if (opcode == SubtractInstruction.Opcode)
        {
            byte register1 = memory.ReadWord8(IP);
            IP += 1;
            byte register2 = memory.ReadWord8(IP);
            IP += 1;
            byte register3 = memory.ReadWord8(IP);
            IP += 1;

            return new SubtractInstruction((Register)register1, (Register)register2, (Register)register3);
        }

        // [OP][R][A]
        if (opcode == StoreInstruction.Opcode)
        {
            byte register = memory.ReadWord8(IP);
            IP += 1;
            int address = memory.ReadWord32(IP);

            if (address < 0)
            {
                throw new Exception($"Memory address at {IP} cannot have a negative values.");
            }
    
            IP += 4;

            return new StoreInstruction((Register)register, (uint)address);
        }

        // [OP][R][R]
        if (opcode == MoveInstruction.Opcode)
        {
            byte register1 = memory.ReadWord8(IP);
            IP += 1;
            byte register2 = memory.ReadWord8(IP);
            IP += 1;

            return new MoveInstruction((Register)register1, (Register)register2);
        }

        // [OP][A]
        if (opcode == JumpInstruction.Opcode)
        {
            int address = memory.ReadWord32(IP);

            if (address < 0)
            {
                throw new Exception($"Memory address at {IP} cannot have a negative values.");
            }

            IP += 4;

            return new JumpInstruction((uint)address);
        }

        // [OP][R][A]
        if (opcode == JumpIfZeroInstruction.Opcode)
        {
            byte register = memory.ReadWord8(IP);
            IP += 1;
            int address = memory.ReadWord32(IP);

            if (address < 0)
            {
                throw new Exception($"Memory address at {IP} cannot have a negative values.");
            }

            IP += 4;

            return new JumpIfZeroInstruction((Register)register, (uint)address);
        }

        // [OP][R][I]
        if (opcode == HaltInstruction.Opcode)
        {
            return new HaltInstruction();
        }

        throw new Exception($"Invalid opcode at {IP - 1}.");
    }
}