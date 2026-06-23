namespace FastCqrs;

public readonly struct Unit : IEquatable<Unit>, IComparable<Unit>
{
    public static readonly Unit Value = default;

    private static readonly ValueTask<Unit> CompletedValueTask = new(Value);

    /// <summary>A completed <see cref="ValueTask{Unit}"/>, useful for returning from void-ish handlers.</summary>
    public static ValueTask<Unit> Task => CompletedValueTask;

    public bool Equals(Unit other) => true;

    public override bool Equals(object? obj) => obj is Unit;

    public override int GetHashCode() => 0;

    public int CompareTo(Unit other) => 0;

    public override string ToString() => "()";

    public static bool operator ==(Unit left, Unit right) => true;

    public static bool operator !=(Unit left, Unit right) => false;
}
