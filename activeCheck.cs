using UnityEngine;
using UnityEngine.UI;

public class ActiveObjectChecker : MonoBehaviour
{
    public Button checkButton6;
    public Button checkButton5;
    public Button checkButton4;
    public Button checkButton3;
    public Button checkButton2;
    public Button checkButton1;
    public GameObject Popup;
    public GameObject Buttons;

    public void CheckActiveGameObjects()
    {
        bool allInactive =
            !checkButton1.gameObject.activeInHierarchy &&
            !checkButton2.gameObject.activeInHierarchy &&
            !checkButton3.gameObject.activeInHierarchy &&
            !checkButton4.gameObject.activeInHierarchy &&
            !checkButton5.gameObject.activeInHierarchy &&
            !checkButton6.gameObject.activeInHierarchy;

        if (allInactive)
        {
            Popup.SetActive(true);
            Buttons.SetActive(false);
        }
        else
        {
            Debug.Log(" Some check buttons are still active.");
        }
    }
}
