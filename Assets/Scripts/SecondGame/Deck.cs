using System.Collections.Generic;
using UnityEngine.UI;

namespace SecondGame
{
    public class Deck
    {
        private List<Card> _cards;
        private List<Image> _imageCards;

        public Deck()
        {
            _cards = new List<Card>();

            foreach (Suit suit in System.Enum.GetValues(typeof(Suit)))
            {
                for (int value = 1; value <= 13; value++)
                {
                    _cards.Add(new Card(value, suit));
                }
            }
            Shuffle();
        }

        public void Shuffle()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                int randomIndex = UnityEngine.Random.Range(0, _cards.Count);
                Card temp = _cards[i];
                _cards[i] = _cards[randomIndex];
                _cards[randomIndex] = temp;
            }

            _imageCards = ViewCardsSetrings.instance.ViewCards(_cards);
        }

        public Image DrawCard()
        {
            if (_imageCards.Count == 0)
                return null;

            Image card = _imageCards[0];
            _cards.RemoveAt(0);
            return card;
        }
    }
}