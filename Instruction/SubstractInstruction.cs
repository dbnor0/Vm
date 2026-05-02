namespace Vm.Instruction;

public class SubtractInstruction : IInstruction
{
    public Register Source1 { get; set; }
    public Register Source2 { get; set; }
    public Register Destination { get; set; }

    public static byte Opcode => 0x04;

    public SubtractInstruction(Register source1, Register source2, Register target)
    {
        Source1 = source1;
        Source2 = source2;
        Destination = target;
    }

    public void Execute(VirtualMachine vm)
    {
        int value1 = vm.cpu.Registers[(int)Source1];
        int value2 = vm.cpu.Registers[(int)Source2];
        vm.cpu.Registers[(int)Destination] = value1 - value2;
    }
}