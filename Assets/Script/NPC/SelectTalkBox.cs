using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTalkBox : MonoBehaviour
{
    Button button;
    Text boxtText;
    Event nextEvent;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        boxtText = transform.Find("Text").GetComponent<Text>();
    }
    public void SetTalkBox(string s, Event nextevent)
    {
        boxtText.text = s;
        nextEvent = nextevent;
    }
    
    public void SelectBoxClick()
    {
        if (nextEvent != null)
        {
        }
    }


}
