using UnityEngine;
using UnityEngine.UI;

namespace SecondGame
{
    public class ActiveCard : MonoBehaviour
    {
        public static ActiveCard Instance;
        private Image _imageCard;

        public void Start()
        {
            if (Instance != null)
                Destroy(gameObject);

            Instance = this;

            if (gameObject.GetComponent<Image>())
            {
                _imageCard = gameObject.GetComponent<Image>();
            }
            else
            {
                Debug.LogError("Пустая переменная Image у активной карты");
            }
        }

        public void SetImageActiveCard(Sprite image)
        {
            _imageCard.sprite = image;
        }
    }
}
