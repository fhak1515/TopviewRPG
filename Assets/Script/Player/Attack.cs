using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] protected Player player;
    [SerializeField] protected PlayerInfo playerinfo;
    [SerializeField] protected BoxCollider m_collider;

    public void AttackStart()
    {
        gameObject.SetActive(true);
    }
    public void TriggerEnd()
    {
        gameObject.SetActive(false);
    }
}
