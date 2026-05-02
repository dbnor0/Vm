namespace Vm.Instruction;

public class LoadImmediateInstruction : IInstruction
{
    public Register Destination;
    public int Immediate;

    public static byte Opcode => 0x01;

    public LoadImmediateInstruction(Register target, int immediate)
    {
        Destination = target;
        Immediate = immediate;
    }

    public void Execute(VirtualMachine vm)
    {
        vm.cpu.Registers[(int)Destination] = Immediate;
    }   
}