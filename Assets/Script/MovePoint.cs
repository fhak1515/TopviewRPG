using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    Animation m_animation;

   
    public Transform ShowPoint(Vector3 world)
    {
        gameObject.SetActive(true);
        transform.position = world;
        return transform;
    }
    public void HidePoint()
    {
        transform.position = Vector3.zero;
        gameObject.SetActive(false);
        
    }
    private void Start()
    {
        gameObject.SetActive(false);
        m_animation = GetComponent<Animation>();
    }

    private void Update()
    {
        if (InGameSystem.inGamePause)
        {
            m_animation.Stop();
        }
    }
}
