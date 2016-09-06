namespace _05.Egyptian_Fractions
{
    public class Fraction
    {
        public Fraction(long value)
        {
            this.Value = value;
        }

        public long Value { get; set; }

        public override string ToString()
        {
            return $"1/{this.Value}";
        }
    }
}