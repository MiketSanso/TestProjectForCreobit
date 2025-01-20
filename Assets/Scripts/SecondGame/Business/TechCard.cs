namespace SecondGame
{
    public class TechCard
    {
        public int Value { get; private set; } 
        public Suit CardSuit { get; private set; }

        public TechCard(int value, Suit suit)
        {
            Value = value;
            CardSuit = suit;
        }
    }
}
