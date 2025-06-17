using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextChapter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadChapter2()
    {
        SceneManager.LoadScene(7);
    }
    public void LoadChapter3()
    {
        SceneManager.LoadScene(8);
    }
}
