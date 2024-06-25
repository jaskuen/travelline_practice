// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Accommodations.Models;

public class CurrencyValues
{
    public static decimal Usd { get; } = (decimal)(new Random().NextDouble() * 100) + 1;
    public static decimal Rub { get; } = 1m;
    public static decimal Cny { get; } = (decimal)(new Random().NextDouble() * 12) + 1;

}

public enum Currency
{
    Usd,
    Rub,
    Cny
}


