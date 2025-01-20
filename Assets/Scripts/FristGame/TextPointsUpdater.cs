using TMPro;
using UnityEngine;

namespace FirstGame 
{
    public class TextPointsUpdater : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _textPoints;

        public static TextPointsUpdater instance;

        public void Start()
        {
            if (instance != null)
                Destroy(gameObject);

            instance = this;
            UpdateTextPoints();
        }

        public void UpdateTextPoints()
        {
            _textPoints.text = PlayerPrefs.GetInt("Points").ToString();
        }
    }
}

