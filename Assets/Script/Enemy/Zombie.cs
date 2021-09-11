using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    protected override void EnemeyStart()
    {
        enemyHP = 50;
    }

    protected override void Drop()
    {
        for(int n = 0; n < Random.Range(1, 5); n++)
        {
            InGameSystem.mainPlayerInfo.AddItems(Random.Range(1001,1004));
        }
        InGameSystem.mainPlayerInfo.AddItems(Random.Range(3001, 3003),Random.Range(1,5));
        if (Random.Range(0,10) < 6)
        {
            InGameSystem.mainPlayerInfo.AddItems(4001);
        }
        if (Random.Range(0, 10) < 3)
        {
            InGameSystem.mainPlayerInfo.AddItems(5001);
        }
        InGameSystem.mainPlayerInfo.gold += Random.Range(10,50);
    }
}
