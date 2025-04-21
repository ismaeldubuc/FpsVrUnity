public class Score
{
    public int Value { get; private set; }

    public Score() { Value = 0; }

    public void Increment() => Value++;
    public void Decrement() { if (Value > 0) Value--; }
    public int GetScore() => Value;
}