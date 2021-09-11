using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 targetCha = new Vector3(0,11,-8); //타겟과의 차이

    private void Start()
    {
        // = transform.position - target.transform.position;
    }

    private void Update()
    {
        if (target == null)
        {
            target = InGameSystem.mainPlayer.transform;
        }
        else
        {
            transform.position = target.transform.position + targetCha;
        }
    }
}
