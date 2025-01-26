using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using static UnityEngine.Rendering.DebugUI;

namespace SecondGame
{
    public class GameDeck : RebootActiveCardParent, IPointerDownHandler
    {
        [SerializeField]
        public List<Sprite> _spriteCards { get; private set; }

        private GameObject _prefabAnimationCard;

        private List<int> _values;

        private Sprite _spriteNullCards;

        private ActiveCard _activeCard;

        private List<GameCard> _cards;

        private void Start()
        {
            ActivateAction();
        }

        public void Init(List<Sprite> spriteCards, List<int> values, ActiveCard activeCard, Sprite spriteNullCards, List<GameCard> cards, GameObject prefabAnimationCard)
        {
            _spriteCards = spriteCards;
            _values = values;
            _activeCard = activeCard;
            _spriteNullCards = spriteNullCards;
            _cards = cards;
            _prefabAnimationCard = prefabAnimationCard;
        }

        public bool SearchTrueElements()
        {
            if (_spriteCards != null && _spriteCards.Count == 0)
            {
                for (int i = 0; i < _cards.Count; i++)
                {
                    if (_cards[i] != null && _cards[i].CheckFreeAndPlayableCard())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public async void OnPointerDown(PointerEventData eventData)
        {
            if (_spriteCards.Count > 0)
            {
                await MovingCard();
            }
        }

        async UniTask MovingCard()
        {
            Sprite spriteCard = _spriteCards[0];

            PlayerPrefs.SetInt("ActiveNumberCard", _values[0]);
            PlayerPrefs.SetInt("Moves", PlayerPrefs.GetInt("Moves") + 1);

            _spriteCards.RemoveAt(0);
            _values.RemoveAt(0);

            if (_spriteCards.Count == 0 && gameObject.GetComponent<Image>())
            {
                gameObject.GetComponent<Image>().sprite = _spriteNullCards;
            }

            GameObject animationObject = Instantiate(_prefabAnimationCard, gameObject.transform.parent);

            animationObject.transform.position = transform.position;
            animationObject.transform.DOMove(_activeCard.transform.position, 0.2f);

            await UniTask.Delay(200);

            Destroy(animationObject);

            _activeCard.SetImageActiveCard(spriteCard);

            ActivateAction();
        }
    }
}
