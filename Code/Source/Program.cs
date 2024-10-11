namespace Lab;

/// Entry point to the program, which does not take any arguments as an input
public class Program
{
    public static void Main(String[] args)
    {
        Lib.Text.Message m;
        char[] a;
        /// Lnaguage Input
        Console.Write("Enter your language (\'Russian\' for example): ");
        var lang = Console.ReadLine();
        Console.Write("\n");
        switch (lang)
        {
            case "Russian": a = [.. new Lib.Text.Alphabet.Russian()]; break;
            case "English": a = [.. new Lib.Text.Alphabet.English()]; break;
            default: throw new NotImplementedException("Language is yet to be implemented.");
        }
		if (args[0].Length > 0) m = new(args[0].ToCharArray());
		else
		{
			// Name input
		    Console.Write("Enter your full name: ");
		    m = new([.. Console.ReadLine()]);
		    Console.Write("\n");
		}
		      		

        /// Seeded Generation
        Console.Write("\n\n\n\n Seeded Generation:\n");
        int seed = 200;

        double h = Lib.Math.Entropy.Harthley(a);
        double s = Lib.Math.Entropy.Shenon(a, seed);
        double sl = Lib.Math.Entropy.Shenon_Linked(a, seed);

        Console.Write("___________________________________________");
        Console.Write("_____________________________________\n");
        Console.WriteLine("Harthleys Entropy:\t\t\t" + System.Math.Round(h, 4) + "\t\t\tBits per Symbol.\n" + "Amount of Information:\t\t\t" + Calculate(m.Length, h) + "\t\t\tBytes.\n");

        Console.Write("___________________________________________");
        Console.Write("_____________________________________\n");
        Console.WriteLine("Shenons Entropy:\t\t\t" + System.Math.Round(s, 4) + "\t\t\tBits per Symbol.\n" + "Amount of Information:\t\t\t" + Calculate(m.Length, s) + "\t\t\tBytes.\n");

        Console.Write("___________________________________________");
        Console.Write("_____________________________________\n");
        Console.WriteLine("Shenons Linked Entropy:\t\t\t" + System.Math.Round(sl, 4) + "\t\tBits per Symbol.\n" + "Amount of Information:\t\t\t" + Calculate(m.Length, sl) + "\t\t\tBytes.\n");

        /// Message Based Generation

        Console.Write("\n\n\n\n Message Based Generation:\n");
        char[] mm = m.ToArray();
        double[] probs = new Lib.Math.Generator().NextDouble(a, mm); // each by itself
        double[][] probs2 = new Lib.Math.Generator().NextRelatedDouble(a, mm); // each with each

        double mh = Lib.Math.Entropy.Harthley(a);
        double ms = Lib.Math.Entropy.Shenon(a, probs);
        double msl = Lib.Math.Entropy.Shenon_Linked(a, probs, probs2);

        Console.Write("___________________________________________");
        Console.Write("_____________________________________\n");
        Console.WriteLine("Harthleys Entropy:\t\t\t" + System.Math.Round(mh, 4) + "\t\t\tBits per Symbol.\n" + "Amount of Information:\t\t\t" + Calculate(m.Length, mh) + "\t\t\tBytes.\n");

        Console.Write("___________________________________________");
        Console.Write("_____________________________________\n");
        Console.WriteLine("Shenons Entropy:\t\t\t" + System.Math.Round(ms, 4) + "\t\t\tBits per Symbol.\n" + "Amount of Information:\t\t\t" + Calculate(m.Length, ms) + "\t\t\tBytes.\n");

        Console.Write("___________________________________________");
        Console.Write("_____________________________________\n");
        Console.WriteLine("Shenons Linked Entropy:\t\t\t" + System.Math.Round(msl, 4) + "\t\tBits per Symbol.\n" + "Amount of Information:\t\t\t" + Calculate(m.Length, msl) + "\t\t\tBytes.\n");

        Console.Write("\n\n");
        Console.WriteLine("End.");

    }

    static double Calculate(long length, double entropy) => Lib.Math.Calculator.Format(Lib.Math.Calculator.ToBit(length, entropy));
}
