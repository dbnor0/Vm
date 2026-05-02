using Vm.Instruction;

namespace Vm;

public static class InstructionEncoder
{
    public static void Encode(ref uint offset, IInstruction instruction, Memory memory)
    {
        // [OP][R][I]
        if (instruction is LoadImmediateInstruction loadi)
        {
            memory.SetWord8(offset, LoadImmediateInstruction.Opcode);
            offset += 1;
            memory.SetWord8(offset, (byte)loadi.Destination);
            offset += 1;
            memory.SetWord32(offset, loadi.Immediate);
            offset += 4;

            return;
        }

        // [OP][R][A]
        if (instruction is LoadMemoryInstruction loadm)
        {
            memory.SetWord8(offset, LoadMemoryInstruction.Opcode);
            offset += 1;
            memory.SetWord8(offset, (byte)loadm.Destination);
            offset += 1;
            memory.SetWord32(offset, loadm.Address);

            return;
        }

        // [OP][R][R][R]
        if (instruction is AddInstruction add)
        {
            memory.SetWord8(offset, AddInstruction.Opcode);
            offset += 1;
            memory.SetWord8(offset, (byte)add.Source1);
            offset += 1;
            memory.SetWord8(offset, (byte)add.Source2);
            offset += 1;
            memory.SetWord8(offset, (byte)add.Destination);
            offset += 1;

            return;
        }

        // [OP][R][R][R]
        if (instruction is SubtractInstruction sub)
        {
            memory.SetWord8(offset, SubtractInstruction.Opcode);
            offset += 1;
            memory.SetWord8(offset, (byte)sub.Source1);
            offset += 1;
            memory.SetWord8(offset, (byte)sub.Source2);
            offset += 1;
            memory.SetWord8(offset, (byte)sub.Destination);
            offset += 1;

            return;
        }

        // [OP][R][A]
        if (instruction is StoreInstruction store)
        {
            memory.SetWord8(offset, StoreInstruction.Opcode);
            offset += 1;
            memory.SetWord8(offset, (byte)store.Source);
            offset += 1;
            memory.SetWord32(offset, store.Destination);
            offset += 4;

            return;
        }

        // [OP][R][R]
        if (instruction is MoveInstruction mov)
        {
            memory.SetWord8(offset, StoreInstruction.Opcode);
            offset += 1;
            memory.SetWord8(offset, (byte)mov.Source);
            offset += 1;
            memory.SetWord8(offset, (byte)mov.Destination);
            offset += 1;

            return;
        }

        // [OP][A]
        if (instruction is JumpInstruction jump)
        {
            memory.SetWord8(offset, JumpInstruction.Opcode);
            offset += 1;
            memory.SetWord32(offset, jump.Destination);
            offset += 4;

            return;
        }

        // [OP][R][A]
        if (instruction is JumpIfZeroInstruction jumpiz)
        {
            memory.SetWord8(offset, JumpIfZeroInstruction.Opcode);
            offset += 1;
            memory.SetWord8(offset, (byte)jumpiz.Register);
            offset += 1;
            memory.SetWord32(offset, jumpiz.Destination);
            offset += 4;

            return;
        }

        // [OP]
        if (instruction is HaltInstruction)
        {
            memory.SetWord8(offset, HaltInstruction.Opcode);
            offset += 1;

            return;
        }

        throw new Exception("Received invalid instruction.");
    }
}