using UnityEngine;
using UnityEngine.InputSystem;

public class MapZoom : MonoBehaviour
{
    public RectTransform mapRectTransform;
    public Canvas canvas;
    public float zoomSpeed = 0.1f;
    public float maxScale = 2.0f;

    private float minScale;
    private Vector3 startScale;
    private Vector2 startAnchoredPosition;

    void Start()
    {
        this.enabled = false;

        if (mapRectTransform != null)
        {
            startScale = mapRectTransform.localScale;
            startAnchoredPosition = mapRectTransform.anchoredPosition;
            minScale = startScale.x;
        }
    }

    public void EnableZoom()
    {
        this.enabled = true;
    }

    void Update()
    {
        if (Mouse.current == null || mapRectTransform == null || canvas == null)
            return;

        float scroll = Mouse.current.scroll.ReadValue().y;

        if (Mathf.Abs(scroll) > 0.01f)
        {
            float currentScale = mapRectTransform.localScale.x;

            if (scroll < 0 && currentScale <= minScale)
                return;

            float targetScale = Mathf.Clamp(currentScale + scroll * zoomSpeed, minScale, maxScale);
            float scaleFactor = targetScale / currentScale;

            if (scroll > 0)
            {
                Vector2 mousePosition = Mouse.current.position.ReadValue();
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    mapRectTransform,
                    mousePosition,
                    canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera,
                    out Vector2 localCursorPosition
                );

                Vector2 beforeZoom = mapRectTransform.anchoredPosition - localCursorPosition;

                mapRectTransform.localScale = new Vector3(targetScale, targetScale, 1f);
                Vector2 afterZoom = beforeZoom * scaleFactor + localCursorPosition;
                mapRectTransform.anchoredPosition = afterZoom;
            }
            else
            {
                mapRectTransform.localScale = new Vector3(targetScale, targetScale, 1f);
                float t = (targetScale - minScale) / (maxScale - minScale);
                mapRectTransform.anchoredPosition = Vector2.Lerp(mapRectTransform.anchoredPosition, startAnchoredPosition, 1 - t);
            }
        }
    }
}
