using System.Collections.Generic;
using UnityEngine;

namespace SecondGame
{
    public class ViewCardsSetrings : MonoBehaviour
    {
        public static ViewCardsSetrings instance;

        [SerializeField]
        private Sprite[] Spades = new Sprite[13];

        [SerializeField]
        private Sprite[] Diamonds = new Sprite[13];

        [SerializeField]
        private Sprite[] Hearts = new Sprite[13];

        [SerializeField]
        private Sprite[] Clubs = new Sprite[13];

        private List<Sprite> _cards;

        public void Awake()
        {
            if (instance != null)
                Destroy(gameObject);

            instance = this;
        }

        public List<Sprite> ViewCards(List<TechCard> cardsInDeck)
        {
            _cards = new List<Sprite>();

            for (int i = 0; i < cardsInDeck.Count; i++)
            {
                Sprite spriteForImage;

                switch (cardsInDeck[i].CardSuit)
                {
                    case Suit.Spades:
                        spriteForImage = Spades[cardsInDeck[i].Value];
                        break;
                    case Suit.Hearts:
                        spriteForImage = Hearts[cardsInDeck[i].Value];
                        break;
                    case Suit.Diamonds:
                        spriteForImage = Diamonds[cardsInDeck[i].Value];
                        break;
                    case Suit.Clubs:
                        spriteForImage = Clubs[cardsInDeck[i].Value];
                        break;
                    default:
                        return null;
                }

                _cards.Add(spriteForImage);
                _cards[i] = spriteForImage;
            }

            return _cards;
        }
    }
}
