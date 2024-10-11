namespace Lib.Math;

/// Operates on Text (for now only counts character ocurrance in text )
public static class Analyser
{
    // Returns how much times c occurs in t;
    public static long Count(char c, char[] t) => t.Where(x => x.Equals(c)).ToArray().Length;


    // For each in ch counts how much c occurs in t
    public static long[] Count(char[] ch, char[] t)
    {
        long[] o = new long[ch.Length];
        for (int c = 0; c < ch.Length; c++) o[c] = Analyser.Count(ch[c], t);
        return o;
    }
}
