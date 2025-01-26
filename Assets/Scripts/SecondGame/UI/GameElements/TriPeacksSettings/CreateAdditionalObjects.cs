using UnityEngine;
using UnityEngine.UI;

namespace SecondGame
{
    public class CreateAdditionalObjects : MonoBehaviour
    {
        public Image CreateObject(Vector2 _positionForDeck, GameObject _parentObject, Sprite spriteObject, Image prefabObject)
        {
            Image activeCardImage = Instantiate(prefabObject, _positionForDeck, Quaternion.identity, _parentObject.transform);

            activeCardImage.sprite = spriteObject;

            return activeCardImage;
        }
    }
}