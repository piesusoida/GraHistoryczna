using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Chronology : MonoBehaviour
{
    public DropDrop[] dropSlots;
    public GameObject PopUpMistake3;
    public GameObject PopUpMistake4;
    public GameObject PopUpMistake5;
    public GameObject ZmianyBase;
    public GameObject ButtonChoice1;
    public GameObject ButtonChoice2;
    public GameObject ButtonChoice3;
    public GameObject Set1;
    public GameObject Set2;


    private void Awake()
    {
        dropSlots = GetComponentsInChildren<DropDrop>();
    }

    public void CheckAllSlots(GameObject buttonClicked)
    {
        bool allCorrect = true;

        foreach (var slot in dropSlots)
        {
            Debug.Log(slot);
            if (!slot.IsCorrectItemPlaced())
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            ChooseMistake(buttonClicked);
        }
        else
        {
            PopUpMistake5.gameObject.SetActive(true);
            ZmianyBase.gameObject.SetActive(false);
        }
    }

    public void ChooseMistake(GameObject buttonClicked)
    {
        if (buttonClicked == ButtonChoice1)
        {
            PopUpMistake3.SetActive(true);
            ZmianyBase.SetActive(false);

        }
        else if (buttonClicked == ButtonChoice2)
        {
            Set2.SetActive(true);
            Set1.SetActive(false);
        }
        else if (buttonClicked == ButtonChoice3)
        {
            PopUpMistake4.SetActive(true);
            ZmianyBase.SetActive(false);
        }

    }

}

