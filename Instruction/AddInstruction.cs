namespace Vm.Instruction;

public class AddInstruction : IInstruction
{
    public Register Source1;
    public Register Source2;
    public Register Destination;

    public static byte Opcode => 0x03;

    public AddInstruction(Register source1, Register source2, Register target)
    {
        Source1 = source1;
        Source2 = source2;
        Destination = target;
    }

    public void Execute(VirtualMachine vm)
    {
        int value1 = vm.cpu.Registers[(int)Source1];
        int value2 = vm.cpu.Registers[(int)Source2];
        vm.cpu.Registers[(int)Destination] = value1 + value2;
    }
}