namespace SecondGame
{
    public class Card
    {
        public int Value { get; private set; } 
        public Suit CardSuit { get; private set; }

        public Card(int value, Suit suit)
        {
            Value = value;
            CardSuit = suit;
        }
    }
}
