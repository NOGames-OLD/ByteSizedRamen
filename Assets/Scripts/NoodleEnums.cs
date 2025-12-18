using System;

public enum SauceType
{
    None = 0,
    Salt = 1,
    Pork = 2,
    Soy = 3,
    Miso = 4,
}

[Flags]
public enum ToppingFlags
{
    None        = 0,
    Egg    = 1 << 0,
    Bacon = 1 << 1,
    Seaweed = 1 << 2,
    Ham = 1 << 3,
    Tempura = 1 << 4,

}
