using UnityEngine;
using UnityEngine.UI;

namespace FirstGame
{
    public class SpritesConnector : MonoBehaviour
    {
        [SerializeField]
        private string _backgroundSpriteAdress;

        [SerializeField]
        private string _buttonAddPointSpriteAdress;

        [SerializeField]
        private Image _background;

        [SerializeField]
        private Image _buttonAddPoint;

        private async void Start()
        {
            _background.sprite = await ConnectSprite.LoadSpriteFromAddressable(_backgroundSpriteAdress);
            _buttonAddPoint.sprite = await ConnectSprite.LoadSpriteFromAddressable(_buttonAddPointSpriteAdress);

        }
    }
}
