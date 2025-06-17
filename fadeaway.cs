using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopupController : MonoBehaviour
{
    public GameObject popup;          // Assign the popup GameObject
    public float fadeDuration = 4f;   // Duration of fade out

    private CanvasGroup canvasGroup;
    private Coroutine fadeCoroutine;

    void Start()
    {
        if (popup != null)
        {
            canvasGroup = popup.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = popup.AddComponent<CanvasGroup>();
            }

            popup.SetActive(false);
            canvasGroup.alpha = 0;
        }
    }

    public void ActivatePopUp()
    {
        if (popup == null) return;

        // Stop existing fade-out if it's running
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        popup.SetActive(true);
        canvasGroup.alpha = 1;

        // Start new fade-out
        fadeCoroutine = StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float startAlpha = canvasGroup.alpha;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, time / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0;
        popup.SetActive(false);
        fadeCoroutine = null; // Mark coroutine as done
    }
}
