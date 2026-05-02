namespace Vm;

public interface IInstruction
{
    void Execute(VirtualMachine vm);    
}