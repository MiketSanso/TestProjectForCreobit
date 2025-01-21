using UnityEngine;
using UnityEngine.EventSystems;

public class GameDeck : MonoBehaviour
{
    [SerializeField]

    private Sprite[] _spriteCards;
    private int[] _values;

    public void Init(Sprite[] spriteCards, int[] values)
    {
        _spriteCards = spriteCards;
        _values = values;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerPrefs.SetInt("ActiveNumberCard", _values[0]);
        //Анимация
    }
}
