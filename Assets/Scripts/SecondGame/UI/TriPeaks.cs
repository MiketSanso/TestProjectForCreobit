using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.GPUSort;

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
        private GameObject _cardsParent;

        void Start()
        {
            DealCards();
        }

        private void DealCards()
        {
            _deck = new TechDeck();
            List<GameCard> cards = new List<GameCard>();

            float sizeCardX = _prefabCard.transform.localScale.x;
            float sizeCardY = _prefabCard.transform.localScale.y;

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
                        cards.Add(gameCard);

                        GameCard[] upCards = AssigningTopCards(3, col, row, cards);

                        if (upCards != null)
                        {
                            if (upCards[0] != null)
                                upCards[0].InitUpCards(null, gameCard);

                            if (upCards[1] != null)
                                upCards[1].InitUpCards(gameCard, null);
                        }

                        int numberCard = A(row, col);

                        gameCard.InitCardInfo(_deck.SpriteCards[numberCard], _deck.Cards[A(row, col)].Value);
                    }
                }
            }
        }

        public GameCard[] AssigningTopCards(int countTriangles, int col, int row, List<GameCard> cardList)
        {
            GameCard[] upCards = new GameCard[2];

            if (row != 0)
            {
                for (int i = 1; i <= countTriangles; i++)
                {
                    if (col < row * i + i)
                    {
                        //if (col - 1 >= row * (i - 1) + (i - 1))
                        //{
                        //  if (row == _maxCountRows - 1)
                        //  {
                        //      Debug.Log(A(row - 1, col - 1));
                        //      upCards[0] = cardList[A(row - 1, col - 1)];
                        //  }
                        //  else
                        //   upCards[0] = cardList[A(row - 1, col - i)];
                        //}

                        if (row == _maxCountRows - 1 && i < countTriangles || col + 1 <= row * i + i - 1) 
                        { 
                            if (row == _maxCountRows - 1)
                            {
                                upCards[1] = cardList[A(row - 1, col)];                            
                            }
                            else
                                upCards[1] = cardList[A(row - 1, col - (i - 1))];

                            
                        }
                        return upCards;
                    }
                }
            }

            return null;
        }

        public int A(int row, int col)
        {
            int numberCard = 0;
            for (int i = 0; i < row + 1; i++)
            {
                if (i == row)
                {
                    numberCard += col;
                    return numberCard;
                }

                numberCard += (i + 1) * 3;
            }

            return numberCard;
        }
    }
}
