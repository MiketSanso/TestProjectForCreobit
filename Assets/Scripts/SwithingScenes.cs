using UnityEngine;
using UnityEngine.SceneManagement;

public class SwithingScenes : MonoBehaviour
{
    public void ActivateMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ActivateGame1()
    {
        SceneManager.LoadScene(1);
    }

    public void ActivateGame2()
    {
        SceneManager.LoadScene(2);
    }
}
