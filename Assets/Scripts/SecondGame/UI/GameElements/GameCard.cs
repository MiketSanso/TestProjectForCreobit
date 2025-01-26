using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace SecondGame
{

    public class GameCard : RebootActiveCardParent, IPointerDownHandler
    {
        public bool IsActive
        {
            get { return _isActive; }
            private set { _isActive = value; }
        }

        private bool _isActive = true;

        private Sprite _spriteCard;

        [SerializeField]
        private int _value;

        [SerializeField]
        private GameCard _firstUpCard;

        [SerializeField]
        private GameCard _secondUpCard;

        private static event Action ActionButtonPressed;

        private Vector2 _positionActiveCard;

        private ActiveCard _activeCard;


        private void Start()
        {
            IsActive = true;

            ActionButtonPressed?.Invoke();
        }

        public bool CheckFreeAndPlayableCard()
        {
            return gameObject.GetComponent<Image>().sprite == _spriteCard &&
                  (_value == PlayerPrefs.GetInt("ActiveNumberCard") + 1 ||
                   _value == PlayerPrefs.GetInt("ActiveNumberCard") - 1 ||
                   _value == 0 && PlayerPrefs.GetInt("ActiveNumberCard") == 12 ||
                   _value == 12 && PlayerPrefs.GetInt("ActiveNumberCard") == 0);
        }

        public void InitCardInfo(Sprite spriteCard, int value, ActiveCard activeCard, Vector2 positionActiveCard)
        {
            _spriteCard = spriteCard;
            _positionActiveCard = positionActiveCard;
            _value = value;
            _activeCard = activeCard;
        }

        public void InitUpCards(GameCard firstUpCard, GameCard secondUpCard)
        {
            if (firstUpCard != null)
                _firstUpCard = firstUpCard;

            if (secondUpCard != null)
                _secondUpCard = secondUpCard;
        }

        public async void OnPointerDown(PointerEventData eventData)
        {
            if (!_firstUpCard && !_secondUpCard && (PlayerPrefs.GetInt("ActiveNumberCard") == -1 ||
                PlayerPrefs.GetInt("ActiveNumberCard") + 1 == _value || PlayerPrefs.GetInt("ActiveNumberCard") - 1 == _value ||
                    PlayerPrefs.GetInt("ActiveNumberCard") == 12 && _value == 0 || PlayerPrefs.GetInt("ActiveNumberCard") == 0 && _value == 12))
            {
                PlayerPrefs.SetInt("ActiveNumberCard", _value);
                PlayerPrefs.SetInt("Moves", PlayerPrefs.GetInt("Moves") + 1);

                await MovingCard();
            }
        }

        async UniTask MovingCard()
        {
            transform.DOMove(_positionActiveCard, 0.2f);

            await UniTask.Delay(200);

            IsActive = false;

            _activeCard.SetImageActiveCard(_spriteCard);
            ActionButtonPressed?.Invoke();
            ActivateAction();

            Destroy(gameObject);
        }

        private async void AnotherCardInputed()
        {
            if ((!_firstUpCard || !_firstUpCard.IsActive) && (!_secondUpCard || !_secondUpCard.IsActive) && gameObject.GetComponent<Image>().sprite != _spriteCard)
            {
                await AnimationCard();
            }
        }

        async UniTask AnimationCard()
        {
            transform.DOMove(new Vector2(transform.position.x + 0.02f, transform.position.y), 0.1f);

            await UniTask.Delay(100);

            transform.DOMove(new Vector2(transform.position.x - 0.04f, transform.position.y), 0.1f);

            await UniTask.Delay(50);

            gameObject.GetComponent<Image>().sprite = _spriteCard;

            await UniTask.Delay(50);

            transform.DOMove(new Vector2(transform.position.x + 0.02f, transform.position.y), 0.1f);

        }

        private void OnEnable()
        {
            ActionButtonPressed += AnotherCardInputed;
        }

        private void OnDisable()
        {
            ActionButtonPressed -= AnotherCardInputed;
        }
    }
}