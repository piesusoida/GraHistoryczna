using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonHitbox : MonoBehaviour
{
	public TMP_Text text_tmp;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

	public void ViewText(string text)
    {
        text_tmp.text = "Ups...\nTo nie jest Francja, a " + text + ".\nNastępnym razem ci się uda!!!";
    }
}
