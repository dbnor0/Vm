namespace Vm.Instruction;

public class JumpIfZeroInstruction : IInstruction
{
    public Register Register { get; set; }
    public uint Destination { get; set; }

    public static byte Opcode => 0x08;

    public JumpIfZeroInstruction(Register register, uint destination)
    {
        Register = register;
        Destination = destination;
    }

    public void Execute(VirtualMachine vm)
    {
        if (vm.cpu.Registers[(int)Register] == 0)
        {
            vm.cpu.InstructionPointer = Destination;
        }
    }
}