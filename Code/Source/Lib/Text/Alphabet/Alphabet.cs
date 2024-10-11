namespace Lib.Text.Alphabet;

/// Should have been struct, but I decided to inherit it from Message class.
public class Alphabet(char[] body) : Message(body)
{
    protected override void Init(char[] body)
    {
        // Case-insensitive definition see Russian or English variants as a reference
        foreach (char element in body.Distinct())
        {
            Add(char.ToUpper(element));
            Add(char.ToLower(element));
        }
        Add(' ');
    }
}
