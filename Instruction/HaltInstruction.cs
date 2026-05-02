namespace Vm.Instruction;

public class HaltInstruction : IInstruction
{
    public static byte Opcode => 0x09;

    public HaltInstruction()
    {
    }

    public void Execute(VirtualMachine vm)
    {
        vm.cpu.Halted = true;
    }
}