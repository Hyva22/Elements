using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundCloser : MonoBehaviour
{
    [SerializeField] private bool deactivate = true;
    [SerializeField] private bool destroy = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3[] corners = new Vector3[4];
            GetComponent<RectTransform>().GetWorldCorners(corners);

            var x = Input.mousePosition.x;
            var y = Input.mousePosition.y;

            var bottomLeft = corners[0];
            var bottom = bottomLeft.y;
            var left = bottomLeft.x;

            var topRight = corners[2];
            var top = topRight.y;
            var right = topRight.x;

            if (left > x || x > right ||
                bottom > y || y > top)
            {
                if (deactivate)
                    gameObject.SetActive(false);
                if (destroy)
                    Destroy(gameObject);
            }
        }
    }
}
