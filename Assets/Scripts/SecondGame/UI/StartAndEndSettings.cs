using UnityEngine;

namespace SecondGame
{
    public class StartAndEndSettings : MonoBehaviour
    {
        private void Awake()
        {
            PlayerPrefs.SetInt("ActiveNumberCard", -1);
            PlayerPrefs.SetInt("Moves", 0);
        }

        private void OnDestroy()
        {
            UnloadAssets.UnloadAsset();
        }
    }
}