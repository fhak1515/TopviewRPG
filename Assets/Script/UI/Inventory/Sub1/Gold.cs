using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gold : MonoBehaviour
{
    PlayerInfo m_maininfo;
    Text m_gold;
    private void Start()
    {
        m_maininfo = InGameSystem.mainPlayerInfo;
        m_gold = GetComponent<Text>();
    }
    void Update()
    {
        m_gold.text = m_maininfo.gold.ToString() + "G";
    }
}
