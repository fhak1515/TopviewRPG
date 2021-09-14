using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySub2 : MonoBehaviour
{
    [SerializeField] Canvas[] canvas;
    int showNumber = 0;
    public void ChangeInventorySub2(int n)
    {
        if (showNumber != n)
        {
            canvas[showNumber].enabled = false;
            canvas[n].enabled = true;
            showNumber = n;
        }
    }
}
