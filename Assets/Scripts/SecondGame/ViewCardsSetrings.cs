using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SecondGame
{
    public class ViewCardsSetrings : MonoBehaviour
    {
        public static ViewCardsSetrings instance;

        [SerializeField]
        private Sprite[,] cardSprites = new Sprite[4, 13]; //не отображается двумерный массив

        [SerializeField]
        private Image _card;

        public void Start()
        {
            if (instance != null)
                Destroy(this.gameObject);

            instance = this;
        }

        public List<Image> ViewCards(List<Card> cardsInDeck)
        {
            List<Image> cards = new List<Image>(cardsInDeck.Count);

            for (int i = 0; i < cardsInDeck.Count; i++)
            {
                cards[i].sprite = cardSprites[(int)cardsInDeck[i].CardSuit, cardsInDeck[i].Value];
            }
            return cards;
        }
    }
}
