using UnityEngine;

namespace SecondGame
{
    public class TriPeaks : MonoBehaviour
    {
        private Deck _deck;

        [SerializeField]
        private Card _card;

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
            _deck = new Deck();

            float sizeCardX = _cardObject.transform.localScale.x;
            float sizeCardY = _cardObject.transform.localScale.y;

            for (int row = 0; row < _maxCountRows; row++)
            {
                for (int col = 0; col < (row + 1) * 3; col++)
                {
                    float positionCardX = -sizeCardX * (3 + row) + sizeCardX * 0.5f * row + col * sizeCardX;
                    if (row == 0)
                        positionCardX += sizeCardX * col * 2;
                    else if (row == 1)
                        positionCardX += col > 1 && col <= 3 ? sizeCardX : col > 3 ? sizeCardX * 2 : 0;

                    float positionCardY = -sizeCardY * 0.5f * (row + 1);

                    if (row + 1 != _maxCountRows || (col != (row + 1) * 3 - 2 && col != (row + 1) * 3 - 1))
                        Instantiate(_deck.DrawCard(), new Vector2(positionCardX, positionCardY), Quaternion.identity, _cardsParent.transform);
                }
            }
        }
    }
}
