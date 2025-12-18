using System;

public enum SauceType
{
    None = 0,
    Soy = 1,
    Spice = 2,
}

[Flags]
public enum ToppingFlags
{
    None        = 0,
    Egg    = 1 << 0,
    Shrimp = 1 << 1,
    Seaweed = 1 << 2,
}
