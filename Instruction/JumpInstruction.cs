namespace Vm.Instruction;

public class JumpInstruction : IInstruction
{
    public uint Destination;

    public static byte Opcode => 0x07;

    public JumpInstruction(uint destination)
    {
        Destination = destination;
    }

    public void Execute(VirtualMachine vm)
    {
        vm.cpu.InstructionPointer = Destination;
    }
}