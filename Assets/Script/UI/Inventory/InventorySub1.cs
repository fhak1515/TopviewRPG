using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySub1 : MonoBehaviour
{
    [SerializeField] Canvas[] canvas;
    int number = 0;
    int shownumber = -1;
    // Update is called once per frame
    void Update()
    {
        if (number != shownumber)
        {
            if (shownumber >= 0 && shownumber < canvas.Length) //안전장치
            {
                canvas[shownumber].enabled = false;
            }
            canvas[number].enabled = true;
            shownumber = number;
        }
    }

    public void nextCanvas()
    {
        number++;
        if (number >= canvas.Length)
        {
            number = 0;
        }
        Debug.Log(number);
    }
    public void pevCanvas()
    {
        number--;
        if (number < 0)
        {
            number = canvas.Length -1;
        }
    }
}
