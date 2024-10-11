namespace Lib.Math;

/// Generates probabilities
public class Generator(int seed = 0) : Random(seed)
{
    public double NextDouble(double min, double max) => min + (NextDouble() * (max - min));
    public double[] NextDouble(char[] alphabet)
    {
        double min = 0;
        double max = 1;

        double[] probs = new double[alphabet.Length];

        for (int c = 0; c < alphabet.Length; c++)
        {
            probs[c] = NextDouble(min, max);
            max = 1 - probs[c];
        }
        return probs;
    }

    public double[][] NextRelatedDouble(char[] alphabet)
    {
        int len = alphabet.Length;
        double[][] probs = new double[len][];
        for (int c = 0; c < len; c++) probs[c] = NextDouble(alphabet);
        return probs;
    }

    public double[][] NextRelatedDouble(char[] alphabet, char[] message)
    {
        int len = alphabet.Length;
        double[][] probs = new double[len][];
        for (int c = 0; c < len; c++) probs[c] = NextDouble(alphabet, message);
        return probs;
    }


    /// Calculated probabilities of each alphabet character, based on seeding mesage
    public double[] NextDouble(char[] alphabet, char[] seed_message)
    {
        // probabilities for each character
        double[] probs = new double[alphabet.Length];
        // count occurances of each alphabet character in seeding message
        long[] o = Analyser.Count(alphabet, seed_message);
        // actual calculation algorithm
        for (int c = 0; c < o.Length; c++)
        {
            if (probs[c] == double.NaN)
            {
                probs[c] = 0;
                continue;
            }
            probs[c] = ((double)o[c]) / (long)seed_message.Length;
        }
        return probs;
    }

}
