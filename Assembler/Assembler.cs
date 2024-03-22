namespace Assembler;
public partial class Assembler
{
    private static readonly string[] separator = ["\r\n", "\r", "\n"];
    private static readonly System.Globalization.NumberStyles hexStyle = System.Globalization.NumberStyles.HexNumber;

    public static string Assemble(string input)
    {
        var instructions = input.Replace("\t", "").Split(separator, StringSplitOptions.None);
        var memory = new byte[256];
        Dictionary<string, byte> labels = [];

        for (int i = 0, x = 0; i < instructions.Length; i++)
        {
            if (instructions[i] == "") continue;
            var index = instructions[i].IndexOf("//");
            if (index >= 0) instructions[i] = instructions[i][0..index];
            var parts = instructions[i].Split(' ');
            if (parts.Length == 0) continue;

            switch (instructions[i][0])
            {
                case ':'://used to define labels to be used in goto
                    labels.Add(parts[0][1..], (byte)x);
                    continue;
                case '#'://used to define a contiguos memory block starting from an address                   
                    for (int n = 0; n < parts.Length; n++)
                    {
                        memory[int.Parse(parts[0][1..], hexStyle) + n] = byte.Parse(parts[n], hexStyle);
                    }
                    continue;
                case '@'://used to define a contiguos memory block that ends in the address 
                    for (int n = 0; n < parts.Length; n++)
                    {
                        memory[int.Parse(parts[0][1..], hexStyle) - n] = byte.Parse(parts[n], hexStyle);
                    }
                    continue;
            }

            if (!Enum.TryParse(parts[0], out Instructions mnemonic))
            {
                Console.WriteLine($"Unknown instruction \"{parts[0]}\". Ignoring.\n");
                continue;
            }            

            memory[x] = (byte)mnemonic;
            Console.WriteLine($"\nInstruction {parts[0]}({memory[x]:x2}) added to [{x}] with:");

            if (parts.Length <= 1) 
            {
                x++;
                continue;
            }
            

            if (!(IsHex().IsMatch(parts[1]) || parts[1].StartsWith(':')) && Enum.TryParse(parts[1], out Instructions VideoOpMnemonic))
            {
                memory[x + 1] = (byte)(VideoOpMnemonic - 0x30);
                memory[x + 2] = GetVideoRegMask(parts[2]);
                Console.WriteLine($"Video Operation:{parts[1]}({memory[x + 1]:x2})");
                Console.WriteLine($"Bitmask:{parts[2]}({memory[x + 2]:x2})");
                x += 3;
                continue;
            }
            var mask = GetVideoRegMask(parts[1]);
            if (mask == 0)
            {
                memory[x + 1] = parts[1].StartsWith(':') ?
                labels[parts[1][1..]] :
                byte.Parse(parts[1], hexStyle);
                Console.WriteLine($"Operand:{parts[1]}({memory[x + 1]:x2})");
                x += 2;
            }
            else
            {
                memory[x + 1] = mask;
                Console.WriteLine($"Bitmask:{parts[1]}({memory[x + 1]:x2})");
                if (parts.Length <= 2) 
                {
                    x += 2;
                    continue;
                } 
                memory[x + 2] = byte.Parse(parts[2], hexStyle);
                Console.WriteLine($"Operand:{parts[2]}({memory[x + 2]:x2})");
                x += 3;
            }          
            
        }

        var output = "v3.0 hex words addressed";
        for (int i = 0; i < memory.Length; i++)
        {
            if (i % 16 == 0) output += $"\n{i:x2}:";
            output += $" {memory[i]:x2}";
        }
        return output;
    }

    [System.Text.RegularExpressions.GeneratedRegex(@"\A\b(0[xX])?[0-9a-fA-F]+\b\Z")]
    private static partial System.Text.RegularExpressions.Regex IsHex();

    private static byte GetVideoRegMask(string input)
    {
        byte output = new();
        output |= (byte)(input.Contains('X') ? 0x1 : 0x0);
        output |= (byte)(input.Contains('Y') ? 0x2 : 0x0);
        output |= (byte)(input.Contains('R') ? 0x4 : 0x0);
        output |= (byte)(input.Contains('G') ? 0x8 : 0x0);
        output |= (byte)(input.Contains('B') ? 0x10 : 0x0);
        output |= (byte)(input.Contains('O') ? 0x20 : 0x0);
        return output;
    }
}
