using System.Collections.Generic;
using UnityEngine;

namespace SecondGame
{
    public class TechDeck
    {
        public List<TechCard> Cards { get; private set; }
        public Sprite[] SpriteCards {  get; private set; }

        public TechDeck()
        {
            Cards = new List<TechCard>();

            foreach (Suit suit in System.Enum.GetValues(typeof(Suit)))
            {
                for (int value = 0; value < 13; value++)
                {
                    Cards.Add(new TechCard(value, suit));
                }
            }
            Shuffle();
        }

        public void Shuffle()
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                int randomIndex = Random.Range(0, Cards.Count);
                TechCard temp = Cards[i];
                Cards[i] = Cards[randomIndex];
                Cards[randomIndex] = temp;
            }

            SpriteCards = ViewCardsSetrings.instance.ViewCards(Cards);
        }
    }
}