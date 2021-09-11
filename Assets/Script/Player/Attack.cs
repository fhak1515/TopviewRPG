using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] protected Player player;
    [SerializeField] protected PlayerInfo playerinfo;

    public void AttackStart() // Ω√¿€
    {
        
    }
    public void AttackEnd()
    {
        transform.gameObject.SetActive(false);
    }
}
