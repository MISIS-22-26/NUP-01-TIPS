namespace Lib.Text;

/// MEssage represents generic message type, made for convinience of initiating begginning values with Init function in both messaged and alphabets
public class Message : List<char>
{
    public Message(char[] body) => Init(body);

    public long Length => Count;

    protected virtual void Init(char[] body)
    {
        foreach (char element in body) Add(element);
    }

}
