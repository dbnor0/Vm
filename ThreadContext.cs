namespace Vm;

public class ThreadContext
{
    public int[] Registers { get; set; } = new int[Cpu.REGISTER_COUNT];
    public uint InstructionPointer { get; set; }
    public bool Halted { get; set; } = false;
}