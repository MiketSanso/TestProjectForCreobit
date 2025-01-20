using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameCard : MonoBehaviour, IPointerDownHandler
{ 
    private Sprite _spriteCard;

    private int _value;

    [SerializeField]
    private GameCard _firstUpCard;

    [SerializeField]
    private GameCard _secondUpCard;

    public static event Action ActionButtonPressed;


    public void Init(Sprite spriteCard, GameCard firstUpCard, GameCard secondUpCard, int value)
    {
        _spriteCard = spriteCard;
        _firstUpCard = firstUpCard;
        _secondUpCard = secondUpCard;
        _value = value;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_firstUpCard && !_secondUpCard && !PlayerPrefs.HasKey("ActiveNumberCard") || 
            PlayerPrefs.GetInt("ActiveNumberCard") + 1 == _value || PlayerPrefs.GetInt("ActiveNumberCard") - 1 == _value ||
                PlayerPrefs.GetInt("ActiveNumberCard") == 13 && _value == 1 || PlayerPrefs.GetInt("ActiveNumberCard") == 1 && _value == 13)
        {
            PlayerPrefs.SetInt("ActiveNumberCard", _value);
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
