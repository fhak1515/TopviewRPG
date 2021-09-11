using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] protected Transform player;
    // Start is called before the first frame update


    private void Update()
    {
        transform.LookAt(player.position);
    }

    void Talk()
    {

    }

    protected void TalkMenu() //
    {
        string n1 = "æ»≥Á«œººø‰";
    }

    protected void Action()
    {

    }
}
