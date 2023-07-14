﻿using backend.Controllers;

namespace BackEndTests;

public class TestableDateTimeProvider : DateTimeProvider
{
    protected override DateTime GetUtcNow() => 
        DateTime.Parse("2021-05-12T18:29:30.206924+00:00");
}