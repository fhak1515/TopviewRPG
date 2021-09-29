using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPlayerState : MonoBehaviour
{
    [SerializeField] Text isAttack;
    [SerializeField] Text isDeffend;
    [SerializeField] Text isHP;
    [SerializeField] Text isMP;
    [SerializeField] Text isCri;
    [SerializeField] Text isCriPower;
    string m_attakString;
    string m_deffendString;
    string m_hpString;
    string m_mpString;
    PlayerInfo playinfo;


    void Start()
    {
        playinfo = InGameSystem.mainPlayerInfo;
        m_attakString = isAttack.text;
        m_deffendString = isDeffend.text;
        m_hpString = isHP.text;
        m_mpString = isMP.text;
    }

    // Update is called once per frame
    void Update()
    {
        isAttack.text = m_attakString + playinfo.ALLDamage().ToString();
        isDeffend.text = m_deffendString+playinfo.ALLArm().ToString();
        isHP.text = m_hpString+playinfo.maxHp;
        isMP.text = m_mpString+playinfo.maxMp;
    }
}
