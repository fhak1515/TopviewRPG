using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalAttak : Attack
{
    List<Enemy> triggerEnemy = new List<Enemy>();
    private void OnEnable()
    {
        //transform.parent.gameObject.GetComponent<Playerinfo>();
    }

    private void OnDisable()
    {
        for (int i = 0; i< triggerEnemy.Count; i++)
        {
            triggerEnemy[i].EndHit();
        }
        triggerEnemy.Clear();
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy)
        {
            if (!enemy.GetHit() && !enemy.GetIsDie())
            {
                triggerEnemy.Add(enemy);
                Rigidbody enemyrigd = enemy.GetComponent<Rigidbody>();
                enemy.Hit(playerinfo.ALLDamage());
            }
        }
    }
    public void TriggerEnd()
    {
        AttackEnd();
    }
}
