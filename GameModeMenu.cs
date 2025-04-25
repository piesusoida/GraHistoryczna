using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeMenu : MonoBehaviour
{
    public void PlayKronika()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayMain()
    {
        SceneManager.LoadScene(2);
    }
}
