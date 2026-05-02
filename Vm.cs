namespace Vm;

public class VirtualMachine
{
    public Cpu cpu { get; set; } = new();
    public Memory memory { get; set; } = new();
    public ThreadContext currentThread { get; set; } = new();

    public void Execute()
    {
        for (int i = 0; i < Cpu.REGISTER_COUNT; i++)
        {
            cpu.Registers[i] = currentThread.Registers[i];
        }
        cpu.InstructionPointer = currentThread.InstructionPointer;

        while (!cpu.Halted)
        {
            ExecuteOne();
        }
    }

    public void ExecuteOne()
    {
        IInstruction instruction = InstructionDecoder.Decode(memory, ref cpu.InstructionPointer);
        instruction.Execute(this);
    }

    public void LoadProgram(uint address, IEnumerable<IInstruction> program)
    {
        uint startAddress = address;
        foreach (IInstruction instruction in program)
        {
            InstructionEncoder.Encode(ref address, instruction, memory);
        }

        currentThread = new()
        {
            InstructionPointer = startAddress,
            Halted = false,
        };
    }
}