using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickHide : MonoBehaviour
{
    private const string ButtonName = "backgroundCloser";

    private void Awake()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        GameObject bgCloser = new GameObject(ButtonName);
        bgCloser.transform.parent = canvas.transform;
        RectTransform rectTransform = bgCloser.AddComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        Button button =  bgCloser.AddComponent<Button>();
    }
}
