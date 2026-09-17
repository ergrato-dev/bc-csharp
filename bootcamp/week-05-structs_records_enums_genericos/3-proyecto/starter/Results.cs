// ============================================
// Librería genérica de resultados
// ============================================
// NOTA PARA EL APRENDIZ:
// Esta es la pieza reutilizable del proyecto: NO menciona tu dominio en ninguna línea.
// Si aparece la palabra "habitación", "libro" o "medicamento" aquí, está mal colocada.

/// <summary>Error de dominio como dato (no como excepción). TODO: adapta los códigos a tu dominio.</summary>
public readonly record struct DomainError(string Code, string Message)
{
    public static DomainError NotFound(string key) => new("not_found", $"No existe '{key}'.");

    // TODO: añade al menos DOS factorías más propias de tu dominio
    // (Duplicated, OutOfStock, AlreadyReturned, RoomOccupied...).

    public override string ToString() => $"{Code}: {Message}";
}

/// <summary>Éxito con valor o fallo con error, sin lanzar excepciones.</summary>
public readonly record struct Result<TValue, TError>
{
    private Result(bool isOk, TValue value, TError error)
    {
        IsOk = isOk;
        _value = value;
        _error = error;
    }

    private readonly TValue _value;
    private readonly TError _error;

    public bool IsOk { get; }

    public static Result<TValue, TError> Ok(TValue value) => new(true, value, default!);
    public static Result<TValue, TError> Fail(TError error) => new(false, default!, error);

    /// <summary>Consume el resultado tratando SIEMPRE los dos caminos.</summary>
    public TResult Match<TResult>(Func<TValue, TResult> onOk, Func<TError, TResult> onError)
    {
        ArgumentNullException.ThrowIfNull(onOk);
        ArgumentNullException.ThrowIfNull(onError);
        return IsOk ? onOk(_value) : onError(_error);
    }

    public TValue ValueOr(TValue fallback) => IsOk ? _value : fallback;

    /// <summary>Transforma el valor y propaga el error intacto.</summary>
    public Result<TNext, TError> Map<TNext>(Func<TValue, TNext> map)
    {
        // TODO: implementar. Sobre un Fail, el lambda NO debe ejecutarse.
        throw new NotImplementedException();
    }

    /// <summary>Encadena otra operación que también puede fallar (evita Result anidados).</summary>
    public Result<TNext, TError> Then<TNext>(Func<TValue, Result<TNext, TError>> next)
    {
        // TODO: implementar. Sobre un Fail, devuelve el mismo error sin llamar a next.
        throw new NotImplementedException();
    }

    public override string ToString() => IsOk ? $"Ok({_value})" : $"Fail({_error})";
}

/// <summary>Atajo para el error habitual del proyecto.</summary>
public static class Result
{
    public static Result<TValue, DomainError> Ok<TValue>(TValue value) => Result<TValue, DomainError>.Ok(value);
    public static Result<TValue, DomainError> Fail<TValue>(DomainError error) => Result<TValue, DomainError>.Fail(error);
}
