using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalkBox : MonoBehaviour
{
    public struct SelectTalk
    {
        public int number;
        public string s;
        public Event nextEvent;
    }
    public delegate void selectTalk(int a);
    public delegate void nextTalk();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Show(string s)
    {

    }
    public void Show(string s, List<SelectTalk> selectTalk)
    {
        for (int a = 0; a < selectTalk.Count; a++)
        {
            SelectTalk showtalk = selectTalk[a];
            string showstring = selectTalk[a].s;
        }
    }
}
