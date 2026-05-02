namespace Vm.Instruction;

public class LoadMemoryInstruction : IInstruction
{
    public Register Destination;
    public uint Address;

    public static byte Opcode => 0x02;

    public LoadMemoryInstruction(Register target, uint address)
    {
        Destination = target;
        Address = address;
    }

    public void Execute(VirtualMachine vm)
    {
        int value = vm.memory[Address];
        vm.cpu.Registers[(int)Destination] = value;
    }
}