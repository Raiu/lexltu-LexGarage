using System.Diagnostics.CodeAnalysis;

namespace LexGarage;

public struct Vuid(ulong id) : IEquatable<Vuid> {
    private ulong _number = id;

    private static readonly Random _rand = new();

    ////////////////////////////////////////////////////////////////////////////////

    public Vuid() : this(GenerateRandomVuid()) { }

    ////////////////////////////////////////////////////////////////////////////////

    private static ulong GenerateRandomVuid() {
        byte[] buf = new byte[8];
        _rand.NextBytes(buf);
        return BitConverter.ToUInt64(buf, 0);
    }

    public static Vuid NewVuid() => new(GenerateRandomVuid());

    public readonly bool Equals(Vuid other) => _number == other._number;

    public override readonly bool Equals(object? obj) => obj is Vuid && Equals(obj);

    public static bool operator ==(Vuid a, Vuid b) => a.Equals(b);

    public static bool operator !=(Vuid a, Vuid b) => !a.Equals(b);

    public override readonly int GetHashCode() => _number.GetHashCode();

    public override readonly string ToString() => _number.ToString();

    public readonly string ToString([StringSyntax("NumericFormat")] string? format) => _number.ToString(format);
}
