using System;

namespace backend.Providers;

public class DateTimeProvider
{
    public DateTime UtcNow() =>
        GetUtcNow();

    protected virtual DateTime GetUtcNow() =>
        DateTime.UtcNow;
}