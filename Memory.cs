namespace Vm;

public class Memory
{
    private const int MEMORY_SIZE = 16384;
    private const int WORD32_SIZE = 4;
    private const int WORD8_SIZE = 4;

    private readonly byte[] _memory = new byte[MEMORY_SIZE];

    public byte this[uint address]
    {
        get => _memory[address];
        set => _memory[address] = value;
    }

    public byte ReadWord8(uint address)
    {
        if (address >= MEMORY_SIZE - WORD8_SIZE)
        {
            throw new ArgumentException($"Address {address} out of range.", nameof(address));
        }

        return _memory[address]; 
    }

    public void SetWord8(uint address, byte word8)
    {
        if (address >= MEMORY_SIZE - WORD8_SIZE)
        {
            throw new ArgumentException($"Address {address} out of range.", nameof(address));
        }

        _memory[address] = word8;
    }

    public int ReadWord32(uint address)
    {
        if (address >= MEMORY_SIZE - WORD32_SIZE)
        {
            throw new ArgumentException($"Address {address} out of range.", nameof(address));
        }

        int word64 = (_memory[address] << 24) 
            | (_memory[address + 1] << 16) 
            | (_memory[address + 2] << 8) 
            | _memory[address + 3];

        return word64; 
    }

    public void SetWord32(uint address, int word32)
    {
        if (address >= MEMORY_SIZE - WORD32_SIZE)
        {
            throw new ArgumentException($"Address {address} out of range.", nameof(address));
        }

        _memory[address] = (byte)((word32 >> 24) & 0xFF);
        _memory[address + 1] = (byte)((word32 >> 16) & 0xFF);
        _memory[address + 2] = (byte)((word32 >> 8) & 0xFF);
        _memory[address + 3] = (byte)(word32 & 0xFF);
    }

    public void SetWord32(uint address, uint word32)
    {
        if (address >= MEMORY_SIZE - WORD32_SIZE)
        {
            throw new ArgumentException($"Address {address} out of range.", nameof(address));
        }

        _memory[address] = (byte)((word32 >> 24) & 0xFF);
        _memory[address + 1] = (byte)((word32 >> 16) & 0xFF);
        _memory[address + 2] = (byte)((word32 >> 8) & 0xFF);
        _memory[address + 3] = (byte)(word32 & 0xFF);
    }

}