namespace Vm.Instruction;

public class MoveInstruction : IInstruction
{
    public Register Destination { get; set; }
    public Register Source { get; set; }

    public static byte Opcode => 0x06;

    public MoveInstruction(Register destination, Register source)
    {
        Destination = destination;
        Source = source;
    }

    public void Execute(VirtualMachine vm)
    {
        vm.cpu.Registers[(int)Destination] = vm.cpu.Registers[(int)Source];
    }
}