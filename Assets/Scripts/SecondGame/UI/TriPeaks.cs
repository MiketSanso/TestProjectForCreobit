using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace SecondGame
{
    public class TriPeaks : MonoBehaviour
    {
        private TechDeck _deck;

        [SerializeField]
        private Image _prefabCard;

        [SerializeField]
        private int _maxCountRows;

        [SerializeField]
        private GameObject _cardObject;

        [SerializeField]
        private GameObject _cardsParent;

        void Start()
        {
            DealCards();
        }

        private void DealCards()
        {
            _deck = new TechDeck();
            GameCard[] cards = new GameCard[];

            float sizeCardX = _cardObject.transform.localScale.x;
            float sizeCardY = _cardObject.transform.localScale.y;

            for (int row = 0; row < _maxCountRows; row++)
            {
                for (int col = 0; col < (row + 1) * 3; col++)
                {
                    float positionCardY = -sizeCardY * 0.5f * (row + 1) + 2;
                    float positionCardX = -sizeCardX * (3 + row) + sizeCardX * 0.5f * row + col * sizeCardX;

                    if (row == 0)
                        positionCardX += sizeCardX * col * 2;
                    else if (row == 1)
                        positionCardX += col > 1 && col <= 3 ? sizeCardX : col > 3 ? sizeCardX * 2 : 0;

                    if (row + 1 != _maxCountRows || (col != (row + 1) * 3 - 2 && col != (row + 1) * 3 - 1))
                    {
                        Image spawnedCard = Instantiate(_prefabCard, new Vector2(positionCardX, positionCardY), Quaternion.identity, _cardsParent.transform);
                        GameCard gameCard = spawnedCard.AddComponent<GameCard>();

                        if (col < row + 2 || row == _maxCountRows - 2)
                        {
                            GameCard
                        }
                        else if (col < row * 2 + 2)
                        {

                        }
                        else if (col < row * 3 + 3)
                        {

                        }
                        else
                        {

                        }

                        int numberCard = 0;
                        for (int i = 0; i < row + 1; i++)
                        {
                            if (i == row)
                                numberCard += col + 1;

                            numberCard += (row + 1) * 3;
                        }

                        gameCard.Init(_deck.SpriteCards[numberCard], _prefabCard, _prefabCard, _deck.Cards[numberCard].Value);
                    }
                }
            }
        }
    }
}
