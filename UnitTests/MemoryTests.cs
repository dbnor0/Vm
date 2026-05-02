namespace Vm.UnitTests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class MemoryTests
{
    [TestMethod]
    public void Given_ExistingWord32_When_Reading_Should_DeserializeCorrectly()
    {
        Memory memory = new();
        memory[0] = 0b00001100;
        memory[1] = 0b11110111;
        memory[2] = 0b01010101;
        memory[3] = 0b00001111;

        int expectedResult = 217535759;

        int actualResult = memory.ReadWord32(0);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void Given_ExistingWord32_When_Reading_Should_CastCorrectly()
    {
        Memory memory = new();
        int word64 = 217535759;
        byte expectedByte0 = 0b00001100;
        byte expectedByte1 = 0b11110111;
        byte expectedByte2 = 0b01010101;
        byte expectedByte3 = 0b00001111;

        memory.SetWord32(0, word64);

        Assert.AreEqual(expectedByte0, memory[0]);
        Assert.AreEqual(expectedByte1, memory[1]);
        Assert.AreEqual(expectedByte2, memory[2]);
        Assert.AreEqual(expectedByte3, memory[3]);
    }
}

