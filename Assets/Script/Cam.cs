using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    Transform target;
    Vector3 targetCha = new Vector3(0,11,-8); //타겟과의 차이

    private void Start()
    {
        if (InGameSystem.mainPlayer != null)
        {
            target = InGameSystem.mainPlayer.transform;
        }
    }

    private void Update()
    {
        if (target == null)
        {
            if (InGameSystem.mainPlayer != null)
            {
                target = InGameSystem.mainPlayer.transform;
            }
        }
        else
        {
            transform.position = target.transform.position + targetCha;
        }
    }
}
