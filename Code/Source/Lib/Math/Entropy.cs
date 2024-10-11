namespace Lib.Math;

/// Contains algorithms for entropy calculation
public static class Entropy
{
    public static double Harthley(char[] a) => System.Math.Log2(a.Length);
    public static double Shenon(char[] a, int seed = 0) => Entropy.Shenon(a, new Generator(1 + seed).NextDouble(a));
    public static double Shenon(char[] a, double[] probs)
    {
        var rend_col = 6;
        var tab_size = 8;
        var symb_p_slot = 8;
        var tab_count = 1;

        Console.Write("Shenon's Character Probability List:\n");
        for (int wp = 0; wp < (symb_p_slot + tab_count * tab_size) * rend_col - tab_count * tab_size; wp++) Console.Write("_");
        Console.Write("\n");
        for (int pr = 0; pr < a.Length; pr++)
        {
            var t = "" + System.Math.Round(probs[pr], 1);
            if (t.Equals("1") || t.Equals("0")) t = t + ".0";

            Console.Write("" + a[pr] + " : " + t + "\t\t");
            if ((pr + 1) % 6 == 0) Console.Write("\n");

        }
        Console.Write("\n\n\n");

        double sum = 0;
        for (int c = 0; c < a.Length; c++)
        {
            if (probs[c] == 0) continue;
            sum += probs[c] * System.Math.Log2(probs[c]);
        }
        if (-sum == double.NaN) return 0.0d;
        return -sum;
    }
    public static double Shenon_Linked(char[] a, int seed = 0) => Entropy.Shenon_Linked(a, new Generator(2 + seed).NextDouble(a), new Generator(3 + seed).NextRelatedDouble(a));
    public static double Shenon_Linked(char[] a, double[] probs, double[][] probs2)
    {
        var rend_col = 6;
        var tab_size = 8;
        var symb_p_slot = 8;
        var tab_count = 2;

        double[] p1 = probs;
        double[][] p = probs2;

        Console.Write("Linked Shenons Probability List:\n");
        for (int wp = 0; wp < (symb_p_slot + tab_count * tab_size) * rend_col - tab_count * tab_size; wp++) Console.Write("_");
        Console.Write("\n");
        for (int wp1 = 0; wp1 < p.Length; wp1++)
        {
            for (int wp = 0; wp < p[wp1].Length; wp++)
            {
                var t = "" + System.Math.Round(p[wp1][wp], 1);
                if (t.Equals("1") || t.Equals("0")) t = t + ".0";

                var wpt = "" + a[wp];
                if (wpt.Equals(" ")) wpt = "_";

                var wpt1 = "" + a[wp1];
                if (wpt1.Equals(" ")) wpt1 = "_";

                Console.Write(wpt1 + "" + wpt + " : " + t + "\t\t");
                if ((wp + 1) % 6 == 0) Console.Write("\n");
            }
            Console.Write("\n\n\n");
        }
        Console.Write("\n\n\n\n");


        double sum = 0;

        for (int c = 0; c < a.Length; c++)
        {
            double sum_inner = 0;
            for (int k = 0; k < a.Length; k++)
            {
                if (p[c][k] == 0) continue;
                sum_inner += p[c][k] * System.Math.Log2(p[c][k]);
            }
            sum += p1[c] * sum_inner;
        }
        if (-sum == double.NaN) return 0;
        return -sum;
    }
}
