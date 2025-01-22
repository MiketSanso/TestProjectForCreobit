using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameCard : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private Sprite _spriteCard;

    private int _value;

    [SerializeField]
    private GameCard _firstUpCard;

    [SerializeField]
    private GameCard _secondUpCard;

    public static event Action ActionButtonPressed;

    public void Start()
    {
        ActionButtonPressed?.Invoke();
    }

    public void InitCardInfo(Sprite spriteCard, int value)
    {
        _spriteCard = spriteCard;

        _value = value;
    }

    public void InitUpCards(GameCard firstUpCard, GameCard secondUpCard)
    {
        if (firstUpCard != null) 
            _firstUpCard = firstUpCard;

        if (secondUpCard != null)
            _secondUpCard = secondUpCard;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_firstUpCard && !_secondUpCard && !PlayerPrefs.HasKey("ActiveNumberCard") || 
            PlayerPrefs.GetInt("ActiveNumberCard") + 1 == _value || PlayerPrefs.GetInt("ActiveNumberCard") - 1 == _value ||
                PlayerPrefs.GetInt("ActiveNumberCard") == 13 && _value == 1 || PlayerPrefs.GetInt("ActiveNumberCard") == 1 && _value == 13)
        {
            PlayerPrefs.SetInt("ActiveNumberCard", _value);
            ActiveCard.Instance.SetImageActiveCard(_spriteCard);

            //Анимация

            ActionButtonPressed?.Invoke();
            Destroy(gameObject);
        }
    }

    private void AnotherCardInputed()
    {
        if (!_firstUpCard && !_secondUpCard)
        {
            //анимация
            gameObject.GetComponent<Image>().sprite = _spriteCard;
        }
    }

    public void OnEnable()
    {
        ActionButtonPressed += AnotherCardInputed;
    }

    public void OnDisable()
    {
        ActionButtonPressed -= AnotherCardInputed;
    }
}
