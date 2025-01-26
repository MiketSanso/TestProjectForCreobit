using TMPro;
using UnityEngine;

namespace SecondGame
{
    public class SetTextTime : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _textTime;

        private float floatSeconds = 0;
        private float floatMinutes = 0;
        private float floatHours = 0;

        void Update()
        {
            floatSeconds += Time.deltaTime / 1;

            if (floatSeconds > 59.5)
            {
                floatMinutes += 1;
                floatSeconds = 0;
            }
            if (floatMinutes > 59)
            {
                floatHours += 1;
                floatMinutes = 0;
            }

            _textTime.text = string.Format("{0:00}:{1:00}:{2:00}", floatHours, floatMinutes, floatSeconds);
        }
    }
}