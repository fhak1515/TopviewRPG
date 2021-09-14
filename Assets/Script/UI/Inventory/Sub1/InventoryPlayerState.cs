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

    PlayerInfo playinfo;


    void Start()
    {
        playinfo = InGameSystem.mainPlayerInfo;
    }

    // Update is called once per frame
    void Update()
    {
        isAttack.text += playinfo.ALLDamage().ToString();
        isDeffend.text += playinfo.ALLArm().ToString();
        isHP.text += playinfo.maxHp;
        isMP.text += playinfo.maxMp;
    }
}
