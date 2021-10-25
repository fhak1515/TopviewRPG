using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int enemyCodeNum; //추후 해쉬코드를 이용한 몬스터 데이터
    [SerializeField] protected Animator animator;
    //protected GameObject player;
    protected NavMeshAgent enemyNavMesh;
    protected GameObject player;
    protected int enemyHP;
    protected bool hitCheck;
    protected bool isDie;
    protected bool isPlayerTaget;
    protected bool isAttackPlay;
    protected bool isPause;
    EnemyState enemyState;
    EnemySpawnArea enemySpawnArea;
    Coroutine navCoroutine;

    protected enum EnemyState
    {
        Idle,
        Walk,
        Run,
        Attack,
        Die
    }

    // Start is called before the first frame update
    void Start()
    {
        isPlayerTaget = false;
        isPause = false;
        player = InGameSystem.mainPlayer;
        enemyNavMesh = GetComponent<NavMeshAgent>();
        hitCheck = false;
        isDie = false;
        isAttackPlay = false;
        enemySpawnArea = gameObject.GetComponentInParent<EnemySpawnArea>();
        ChangeSate(EnemyState.Idle);
        EnemeyStart();


    }
    protected  virtual void EnemeyStart()
    {

    }
    public void SetEnemySpawnArea(EnemySpawnArea enemySpawnArea)
    {
        this.enemySpawnArea = enemySpawnArea;
    }
    // Update is called once per frame
    void Update()
    {
        if (InGameSystem.showSubMenu && InGameSystem.inGamePause)
        {
            if (isPause == false)
            {
                enemyNavMesh.isStopped = true;
                enemyNavMesh.velocity = Vector3.zero;
                animator.speed = 0f;
                isPause = true;
                return;
            }
        }
        if (isDie)
        {
            if (enemyNavMesh.enabled)
            {
                enemyNavMesh.velocity = Vector3.zero;
                enemyNavMesh.enabled = false;
                if(navCoroutine != null)
                {
                    StopCoroutine(navCoroutine);
                }
            }
            if (enemyState != EnemyState.Die)
            {
                ChangeSate(EnemyState.Die);
            }
            return;
        }
        if (InGameSystem.showSubMenu && InGameSystem.inGamePause)
        {
            if (isPause == true)
            {
                enemyNavMesh.isStopped = false;
                animator.speed = 1f;
                isPause = false;
            }
        }
        if (player == null){
            player = InGameSystem.mainPlayer;
        }
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= 10f && !isAttackPlay)
            {
                isPlayerTaget = true;
                Move();
                if (navCoroutine == null)
                {
                    navCoroutine = StartCoroutine("TagetPlayer");
                }
            }
            else
            {
                ChangeSate(EnemyState.Idle);
                isPlayerTaget = false;
            }
        }
    }

    public void Hit(int damage)
    {
        enemyHP -= damage;
        Debug.Log(enemyHP + "/ 데미지 "+damage);
        if (enemyHP <= 0)
        {
            isDie = true;
            Destroy(transform.gameObject,3f);
        }
        hitCheck = true;
    }
    protected virtual void Drop() { }

    private void OnDestroy()
    {
        enemySpawnArea.EnemyDie();
        Drop();
    }
    public bool GetHit()
    {
        return hitCheck;
    }
    public void EndHit()
    {
        hitCheck = false;
    }

    public bool GetIsDie()
    {
        return isDie;
    }
    public void Attack()
    {
        transform.LookAt(player.transform.position);
        isAttackPlay = true;
        ChangeSate(EnemyState.Attack);
    }
    public void AttackOut()
    {
        transform.LookAt(player.transform.position);
        isAttackPlay = false;
        ChangeSate(EnemyState.Idle);
    }
    public void Move()
    {
        ChangeSate(EnemyState.Run);
    }


    protected void ChangeSate(EnemyState state)
    {
        enemyState = state;
        animator.SetInteger("State",(int)state);
    }

    IEnumerator TagetPlayer()
    {
        while (isPlayerTaget)
        {
            enemyNavMesh.destination = player.transform.position;
            //Debug.Log(player.transform.position .x+ ", "+player.transform.position.y+", "+player.transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
