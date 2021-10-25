using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackArea : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] NavMeshAgent mesh;
    [SerializeField] LayerMask targetLayer;
    Player m_player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.layer == targetLayer)
        {
            mesh.isStopped = true;
            mesh.velocity = Vector3.zero;
            enemy.Attack();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.layer == targetLayer)
        {
            mesh.isStopped = false;
            enemy.AttackOut();
        }
    }
}
