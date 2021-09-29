using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubButtonAction : MonoBehaviour
{
    RectTransform rect;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    public bool CheckPointIn(Vector3 point)
    {
        Vector3 mouse;
        Vector3 size = rect.sizeDelta * rect.lossyScale;
        Vector3 startpositon = transform.position;
        startpositon.x -= size.x / 2;
        startpositon.y += size.y / 2;
        mouse = point - startpositon;
        if (mouse.x >=0 && mouse.x <= size.x && mouse.y <= 0 && mouse.y >= -size.y)
        {
            return true;
        }
        return false;
    }

}
