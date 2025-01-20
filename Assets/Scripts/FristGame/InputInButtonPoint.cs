using UnityEngine;

namespace FirstGame
{
    public class InputInButtonPoint : MonoBehaviour
    {
        public void Start()
        {
            if (!PlayerPrefs.HasKey("Points"))
                PlayerPrefs.SetInt("Points", 0);
        }

        public void AddPoint()
        {
            PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points") + 1);
            PlayerPrefs.Save();
            TextPointsUpdater.instance.UpdateTextPoints();
        }
    }
}
