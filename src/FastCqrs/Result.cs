namespace FastCqrs;
internal sealed class Result<TValue>
{
    private readonly TValue? _value;
    private readonly IReadOnlyList<Error>? _errors;

    private Result(TValue value)
    {
        _value = value;
        IsSuccess = true;
    }

    private Result(IReadOnlyList<Error> errors)
    {
        _errors = errors;
        IsSuccess = false;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    /// <summary>The success value. Throws if <see cref="IsFailure"/>.</summary>
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("Cannot access Value on a failed Result. Check IsSuccess first.");

    /// <summary>The failure errors. Throws if <see cref="IsSuccess"/>.</summary>
    public IReadOnlyList<Error> Errors => IsFailure
        ? _errors!
        : throw new InvalidOperationException("Cannot access Errors on a successful Result. Check IsFailure first.");

    public static Result<TValue> Ok(TValue value) => new(value);

    public static Result<TValue> Fail(Error error) => new(new[] { error });

    public static Result<TValue> Fail(IReadOnlyList<Error> errors)
    {
        if (errors.Count == 0)
        {
            throw new ArgumentException("At least one error is required for a failed result.", nameof(errors));
        }

        return new(errors);
    }

    public static Result<TValue> Fail(string code, string description) => Fail(new Error(code, description));

    /// <summary>
    /// Pattern-match the result. Exactly one branch is invoked: <paramref name="onSuccess"/> when
    /// <see cref="IsSuccess"/> is true, <paramref name="onFailure"/> otherwise.
    /// </summary>
    public TOut Match<TOut>(Func<TValue, TOut> onSuccess, Func<IReadOnlyList<Error>, TOut> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        return IsSuccess ? onSuccess(_value!) : onFailure(_errors!);
    }

    /// <summary>Implicitly lifts a value into a successful <see cref="Result{TValue}"/>.</summary>
    public static implicit operator Result<TValue>(TValue value) => Ok(value);

    public override string ToString() =>
        IsSuccess ? $"Ok({_value})" : $"Fail([{string.Join(", ", _errors!)}])";
}

/// <summary>Typed success/failure wrapper for operations that have no meaningful success value.</summary>
public sealed class Result
{
    public static readonly Result Ok = new(true, null);

    private readonly bool _isSuccess;
    private readonly IReadOnlyList<Error>? _errors;

    private Result(bool isSuccess, IReadOnlyList<Error>? errors)
    {
        _isSuccess = isSuccess;
        _errors = errors;
    }

    public bool IsSuccess => _isSuccess;
    public bool IsFailure => !_isSuccess;

    public IReadOnlyList<Error> Errors => IsFailure
        ? _errors!
        : throw new InvalidOperationException("Cannot access Errors on a successful Result.");

    public static Result Fail(Error error) => new(false, new[] { error });

    public static Result Fail(IReadOnlyList<Error> errors)
    {
        if (errors.Count == 0)
        {
            throw new ArgumentException("At least one error is required.", nameof(errors));
        }

        return new(false, errors);
    }

    public static Result Fail(string code, string description) => Fail(new Error(code, description));

    public TOut Match<TOut>(Func<TOut> onSuccess, Func<IReadOnlyList<Error>, TOut> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        return IsSuccess ? onSuccess() : onFailure(_errors!);
    }

    public override string ToString() =>
        IsSuccess ? "Ok" : $"Fail([{string.Join(", ", _errors!)}])";
}

/// <summary>A single named problem attached to a <see cref="Result{TValue}"/> or <see cref="Result"/>.</summary>
public readonly record struct Error(string Code, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public static Error NotFound(string description) => new("NOT_FOUND", description);

    public static Error Unauthorized(string description) => new("UNAUTHORIZED", description);

    public static Error Conflict(string description) => new("CONFLICT", description);

    public static Error Validation(string description) => new("VALIDATION", description);

    public override string ToString() => $"{Code}: {Description}";
}
