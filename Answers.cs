using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public void WrongAnswer()
    {
        SceneManager.LoadScene(4);
    }

    public void CorrectAnswer()
    {
        SceneManager.LoadScene(5);
    }
}
