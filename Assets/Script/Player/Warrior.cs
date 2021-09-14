using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public int isHP { private set; get; }
    public int isMP { private set; get; }
    public int isAttack { private set; get; }
    public int isDeffend { private set; get; }

    Warrior()
    {
        isHP = 100;
        isMP = 100;
        isAttack = 10;
        isDeffend = 5;
    }

}
