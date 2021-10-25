using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    [SerializeField] float trunspeed;
    Vector3 baseVector;

    private void Start()
    {
        baseVector = transform.eulerAngles;
    }
    private void Update()
    {
        baseVector.y += Time.deltaTime * trunspeed;
        if (baseVector.y > 360f)
        {
            baseVector.y = 0;
        }
        transform.eulerAngles = baseVector;
    }
}
