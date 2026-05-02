namespace Vm.Instruction;

public class StoreInstruction : IInstruction
{
    public Register Source { get; set; }
    public uint Destination { get; set; }

    public static byte Opcode => 0x05;

    public StoreInstruction(Register source, uint destination)
    {
        Source = source;
        Destination = destination;
    }

    public void Execute(VirtualMachine vm)
    {
        vm.memory.SetWord32(Destination, vm.cpu.Registers[(int)Source]);
    }
}