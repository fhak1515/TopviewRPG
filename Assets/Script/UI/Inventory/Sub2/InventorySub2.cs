using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySub2 : MonoBehaviour
{
    [SerializeField] GameObject[] canvas;
    [SerializeField] Transform main;
    RectTransform m_rectTransform;
    int showNumber = 0;
    bool checkCanvasPoint;
    public void ChangeInventorySub2(int n)
    {
        if (showNumber != n)
        {
            canvas[showNumber].SetActive(false);
            canvas[n].SetActive(true);
            showNumber = n;
        }
    }
    private void Start()
    {
        checkCanvasPoint = false;
        m_rectTransform = GetComponent<RectTransform>();
    }
    public void SortItems()
    {
        canvas[showNumber].GetComponent<InventoryItems>().SortItems();
    }

    public void EnterCanvasPoint()
    {
        canvas[showNumber].GetComponent<InventoryItems>().SetCanvasInPoint(true);
        checkCanvasPoint = true;
        Debug.Log("EnterCanvasPoint");
    }
    public void ExitCanvasPoint()
    {
        canvas[showNumber].GetComponent<InventoryItems>().SetCanvasInPoint(false);
        checkCanvasPoint = false;
        Debug.Log("ExitCanvasPoint");
    }
}
