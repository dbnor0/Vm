using Vm;
using Vm.Instruction;

VirtualMachine vm = new();
IInstruction[] program = [
    new LoadImmediateInstruction(Register.A, 10),
    new LoadImmediateInstruction(Register.B, 20),
    new AddInstruction(Register.A, Register.B, Register.C),
    new StoreInstruction(Register.C, 1000),
    new HaltInstruction(),
];
vm.LoadProgram(0, program);
vm.Execute();
Console.WriteLine(vm.memory.ReadWord32(1000));