namespace Lib.Math;

/// Operates on numeric types (for now calculates inf mass)
public static class Calculator
{
    // Should Be Ceiled
    public static double ToBit(long length, double entropy) => length * entropy;

    public static double ToByte(double bit_size) => 0.125d * bit_size;

    public static double Format(double bits) => System.Math.Ceiling(ToByte(bits));

}
