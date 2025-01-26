using System.Collections.Generic;
using UnityEngine;

namespace SecondGame
{
    public class ViewCardsSetrings : MonoBehaviour
    {
        public static ViewCardsSetrings instance;

        [SerializeField]
        private Sprite[] Clubs = new Sprite[13];

        [SerializeField]
        private Sprite[] Spades = new Sprite[13];

        [SerializeField]
        private Sprite[] Hearts = new Sprite[13];

        [SerializeField]
        private Sprite[] Diamonds = new Sprite[13];

        private List<Sprite> _cards;

        [SerializeField] string _textureAdress;

        public bool isCardsFounded { get; private set; }

        private async void Start()
        {
            if (instance != null)
                Destroy(gameObject);

            instance = this;

            isCardsFounded = false;

            List<Sprite[]> loadedSprites = await ConnectTexture.LoadSpritesDeckFromAddressable(_textureAdress, 4, 13);

            if (loadedSprites != null)
            {
                Clubs = loadedSprites[0];
                Spades = loadedSprites[1];
                Hearts = loadedSprites[2];
                Diamonds = loadedSprites[3];
            }

            isCardsFounded = true;
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
