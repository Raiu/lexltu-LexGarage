using System.Text.RegularExpressions;

namespace LexGarage;

public struct Ruid : IEquatable<Ruid> {

    private readonly ulong _number;

    private static readonly int _length = 6;

    private static readonly string _validCharInput = $"^[A-Za-z0-9]{{{_length}}}$";

    private static readonly Random _rand = new();

    ////////////////////////////////////////////////////////////////////////////////

    public Ruid() : this(NewRuid()) { }

    public Ruid(string id) {
        if (!Validate(id)) {
            throw new ArgumentException($"{id} is an invalid license plate");
        }
        _number =Encode(id);
    }

    ////////////////////////////////////////////////////////////////////////////////

    public static Ruid NewRuid() => new Ruid(GenerateRandomRuid(_length));

    public static bool IsValid(string value) => Validate(value);

    public static Ruid Parse(string value) {
        if (!IsValid(value)) {
            throw new ArgumentException($"{value} is an invalid license plate");
        }
        return new Ruid(value);
    }

    public readonly bool Equals(Ruid other) => _number == other._number;

    public static bool operator ==(Ruid a, Ruid b) => a.Equals(b);

    public static bool operator !=(Ruid a, Ruid b) => !a.Equals(b);

    public override readonly string ToString() => Decode(_number);

    public static implicit operator string(Ruid id) => id.ToString();

    public override readonly int GetHashCode() => _number.GetHashCode();

    public override readonly bool Equals(object? obj) => obj is Ruid && Equals(obj);

    private static bool Validate(string input) => Regex.IsMatch(input, _validCharInput);

    private static ulong Encode(string input) {
        var encoded = "";
        foreach(var c in input.ToUpper()) {
            encoded += (int)c;
        }
        return ulong.Parse(encoded);
    }

    private static string Decode(ulong number) {
        var decoded = "";
        foreach(var seg in Split(number.ToString(), 2)) {
            decoded += (char)int.Parse(seg);
        }
        return decoded;
    }

    private static IEnumerable<string> Split(string str, int size) {
        return Enumerable.Range(0, str.Length / size)
                .Select(i => str.Substring(i * size, size));
    }

    private static string GenerateRandomRuid(int length) {
        var str = "";
        for(var i = 0; i < length / 2; i++) {
            str += (char)_rand.Next('A', 'Z' + 1);
        }
        for(var i = 0; i < length / 2; i++) {
            str += _rand.Next(0, 10);
        }
        return str;
    }
}
