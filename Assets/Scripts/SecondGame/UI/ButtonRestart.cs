using UnityEngine;
using UnityEngine.SceneManagement;

namespace SecondGame
{
    public class ButtonRestart : MonoBehaviour
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(2);
        }
    }
}