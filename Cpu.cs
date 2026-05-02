namespace Vm;

public class Cpu
{
    public static readonly int REGISTER_COUNT = 4;
    public int[] Registers { get; set; } = new int[4];
    public uint InstructionPointer;
    public bool Halted { get; set; } = false;
}