using UnityEngine;

namespace FirstGame
{
    public class StartAndEndSettings : MonoBehaviour
    {
        private void OnDestroy()
        {
            UnloadAssets.UnloadAsset();
        }
    }
}