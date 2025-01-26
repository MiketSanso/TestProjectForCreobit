using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

namespace SecondGame
{
    public class TriPeaks : MonoBehaviour
    {
        private TechDeck _techDeck;

        private Sprite _spriteNullCards;

        private Sprite[] _techCardSprites;

        private GameObject _prefabCard;

        private List<Sprite[]> _listSprites;

        [SerializeField]
        private Vector2 _positionForSpawnDeckAndActiveCard;

        [SerializeField]
        private string textureTechCardSpritesAdress;

        [SerializeField]
        private string prefabImageCardAdress;

        [SerializeField]
        private int _maxCountRows;

        [SerializeField]
        private GameObject _cardsParent;

        [SerializeField]
        private GameFinish _gameFinsh;

        [SerializeField]
        private CreateAdditionalObjects _createAdditionalObject;

        private async void Start()
        {
            _listSprites = await ConnectTexture.LoadSpritesDeckFromAddressable(textureTechCardSpritesAdress, 1, 2);
            _prefabCard = await ConnectPrefabImage.LoadImageFromAddressable(prefabImageCardAdress);

            _techDeck = new TechDeck();
            await WaitCreateDeck(_techDeck);
        }

        private async UniTask WaitCreateDeck(TechDeck deck)
        {
            while (deck.SpriteCards == null || _prefabCard == null || _listSprites.Count == 0)
            {
                await UniTask.Yield();
            }

            _techCardSprites = _listSprites[0];
            _prefabCard.GetComponent<Image>().sprite = _techCardSprites[0];
            _spriteNullCards = _techCardSprites[1];

            DealCards();
        }

        private void DealCards()
        {
            List<GameCard> cards = new List<GameCard>();

            Image gameDeck = _createAdditionalObject.CreateObject(_positionForSpawnDeckAndActiveCard, 
                                                                    _cardsParent,
                                                                        _prefabCard.GetComponent<Image>().sprite, 
                                                                            _prefabCard.GetComponent<Image>());
            gameDeck.AddComponent<GameDeck>();

            Image activeCardImage = _createAdditionalObject.CreateObject(new Vector2(_positionForSpawnDeckAndActiveCard.x * -1, _positionForSpawnDeckAndActiveCard.y), 
                                                                             _cardsParent, 
                                                                                 _spriteNullCards, 
                                                                                     _prefabCard.GetComponent<Image>());
            activeCardImage.AddComponent<ActiveCard>();

            float sizeCardX = _prefabCard.transform.localScale.x;
            float sizeCardY = _prefabCard.transform.localScale.y;

            for (int row = 0; row < _maxCountRows; row++)
            {
                for (int col = 0; col < (row + 1) * 3; col++)
                {
                    float positionCardY = -sizeCardY * 0.5f * (row + 1) + 2;
                    float positionCardX = -sizeCardX * (3 + row) + sizeCardX * 0.5f * row + col * sizeCardX ;

                    if (row == 0)
                        positionCardX += sizeCardX * col * 2;
                    else if (row == 1)
                        positionCardX += col > 1 && col <= 3 ? sizeCardX : col > 3 ? sizeCardX * 2 : 0;

                    if (row + 1 != _maxCountRows || (col != (row + 1) * 3 - 2 && col != (row + 1) * 3 - 1)) //помутить с плюсами.
                    {
                        Image spawnedCard = Instantiate(_prefabCard.GetComponent<Image>(), new Vector2(positionCardX, positionCardY), Quaternion.identity, _cardsParent.transform);
                        GameCard gameCard = spawnedCard.AddComponent<GameCard>();
                        cards.Add(gameCard);

                        GameCard[] upCards = SearchPeaks.AssigningTopCards(3, col, row, cards, _maxCountRows);

                        if (upCards != null)
                        {
                            if (upCards[0] != null)
                                upCards[0].InitUpCards(null, gameCard);

                            if (upCards[1] != null)
                                upCards[1].InitUpCards(gameCard, null);
                        }

                        int numberCard = _techDeck.Cards[0].Value;

                        gameCard.InitCardInfo(_techDeck.SetAndDeleteSprite(), numberCard, activeCardImage.GetComponent<ActiveCard>(), new Vector2(_positionForSpawnDeckAndActiveCard.x * -1, _positionForSpawnDeckAndActiveCard.y));
                    }
                }
            }

            List<int> valueOtherCards = new List<int>();

            for (int i = 0; i < _techDeck.Cards.Count; i++)
                valueOtherCards.Add(_techDeck.Cards[i].Value);

            gameDeck.GetComponent<GameDeck>().Init(_techDeck.SpriteCards, valueOtherCards, activeCardImage.GetComponent<ActiveCard>(), _spriteNullCards, cards, _prefabCard);

            GameCard[] pickTriangles = new GameCard[] { cards[0], cards[1], cards[2] };
            _gameFinsh.Init(pickTriangles, gameDeck.GetComponent<GameDeck>());
        }
    }
}
