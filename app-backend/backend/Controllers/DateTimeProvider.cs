using System;

namespace backend.Controllers;

public class DateTimeProvider
{
    public DateTime UtcNow() => 
        GetUtcNow();

    protected virtual DateTime GetUtcNow() => 
        DateTime.UtcNow;
}