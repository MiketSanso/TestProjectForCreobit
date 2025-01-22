using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameDeck : MonoBehaviour
{
    private List<Sprite> _spriteCards;

    private List<int> _values;

    public void Init(List<Sprite> spriteCards, List<int> values)
    {
        _spriteCards = spriteCards;
        _values = values;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_spriteCards.Count > 0)
        {
            PlayerPrefs.SetInt("ActiveNumberCard", _values[0]);

            ////Анимация

            ActiveCard.Instance.SetImageActiveCard(_spriteCards[0]);

            _spriteCards.RemoveAt(0);
            _values.RemoveAt(0);
        }
    }
}
