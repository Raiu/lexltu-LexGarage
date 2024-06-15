using System.Text;
using System.Text.RegularExpressions;

namespace LexGarage;

public struct Ruid : IEquatable<Ruid> {

    private readonly ulong _number;

    private const string ValidCharInput = "^[A-Za-z0-9]{8}$";

    private static readonly Random _rand = new();

    ////////////////////////////////////////////////////////////////////////////////

    public Ruid() : this(NewRuid()) { }

    public Ruid(string id) {
        Validate(id);
        _number =Encode(id);
    }

    ////////////////////////////////////////////////////////////////////////////////

    public static Ruid NewRuid() => new Ruid(GenerateRandomRuid(8));

    public readonly bool Equals(Ruid other) => _number == other._number;

    public static bool operator ==(Ruid a, Ruid b) => a.Equals(b);

    public static bool operator !=(Ruid a, Ruid b) => !a.Equals(b);

    public override string ToString() => Decode();

    public static implicit operator string(Ruid id) => id.ToString();

    public override readonly int GetHashCode() => _number.GetHashCode();

    public override readonly bool Equals(object? obj) => obj is Ruid && Equals(obj);
    
    private static void Validate(string input) {
        if(!Regex.IsMatch(input, "^[A-Za-z0-9]{8}$")) {
            throw new ArgumentException($"{input} is an invalid license plate");
        }
    }

    private ulong Encode(string input) {
        var encoded = new StringBuilder();
        foreach(var c in input.ToUpper()) {
            encoded.Append((int)c);
        }

        return ulong.Parse(encoded.ToString());
    }

    private string Decode() {
        var decoded = new StringBuilder();
        foreach(var seg in Split(_number.ToString(), 2)) {
            decoded.Append((char)int.Parse(seg));
        }

        return decoded.ToString();
    }

    private static IEnumerable<string> Split(string str, int size) =>
        Enumerable.Range(0, str.Length / size).Select(i => str.Substring(i * size, size));

    private static string GenerateRandomRuid(int length) {
        var sb = new StringBuilder();
        for(var i = 0; i < length / 2; i++) {
            sb.Append((char)_rand.Next('A', 'Z' + 1));
        }

        for(var i = 0; i < length / 2; i++) {
            sb.Append(_rand.Next(0, 10));
        }

        return sb.ToString();
    }


    /* Graveyard

    public override readonly bool Equals(object? obj) {
        if (obj is Regnr other)
            return _number == other._number;
        return false;
    }

    private static readonly Dictionary<char, int> CharToIntMap = new() {
        {'0', 10}, {'1', 11}, {'2', 12}, {'3', 13}, {'4', 14},
        {'5', 15}, {'6', 16}, {'7', 17}, {'8', 18}, {'9', 19},
        {'A', 20}, {'B', 21}, {'C', 22}, {'D', 23}, {'E', 24},
        {'F', 25}, {'G', 26}, {'H', 27}, {'I', 28}, {'J', 29},
        {'K', 30}, {'L', 31}, {'M', 32}, {'N', 33}, {'O', 34},
        {'P', 35}, {'Q', 36}, {'R', 37}, {'S', 38}, {'T', 39},
        {'U', 40}, {'V', 41}, {'W', 42}, {'X', 43}, {'Y', 44}, {'Z', 45}
    };

    private static Dictionary<int, char> IntToCharMap = new() {
        {10, '0'}, {11, '1'}, {12, '2'}, {13, '3'}, {14, '4'},
        {15, '5'}, {16, '6'}, {17, '7'}, {18, '8'}, {19, '9'},
        {20, 'A'}, {21, 'B'}, {22, 'C'}, {23, 'D'}, {24, 'E'},
        {25, 'F'}, {26, 'G'}, {27, 'H'}, {28, 'I'}, {29, 'J'},
        {30, 'K'}, {31, 'L'}, {32, 'M'}, {33, 'N'}, {34, 'O'},
        {35, 'P'}, {36, 'Q'}, {37, 'R'}, {38, 'S'}, {39, 'T'},
        {40, 'U'}, {41, 'V'}, {42, 'W'}, {43, 'X'}, {44, 'Y'}, {45, 'Z'}
    };

    private void Encode(string input) {
        var encoded = "";
        foreach (var c in input.ToUpper())
            encoded += CharToIntMap[c].ToString();
        _number = ulong.Parse(encoded);
    }

    private string Decode() {
        var decoded = "";
        foreach (var seg in Split(_number.ToString(), 2))
            decoded += IntToCharMap[int.Parse(seg)];
        return decoded;
    }
    */
}
