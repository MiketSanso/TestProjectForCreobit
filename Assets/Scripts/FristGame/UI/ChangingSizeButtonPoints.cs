using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

namespace FirstGame
{
    public class ChangingSizeButtonPoints : MonoBehaviour
    {
        public async void ChangeSize(GameObject objectChanging)
        {
            await MovingCard(objectChanging);
        }

        private async UniTask MovingCard(GameObject objectChanging)
        {
            objectChanging.transform.DOScale(new Vector2(objectChanging.transform.localScale.x - 0.2f, objectChanging.transform.localScale.y - 0.2f), 0.03f);

            await UniTask.Delay(30);

            objectChanging.transform.DOScale(new Vector2(objectChanging.transform.localScale.x + 0.2f, objectChanging.transform.localScale.y + 0.2f), 0.03f);
        }
    }
}
