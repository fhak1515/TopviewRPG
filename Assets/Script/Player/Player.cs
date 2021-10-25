using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Animator playerAnimator;
    [SerializeField] PlayerInfo playerinfo;
    [SerializeField] Transform attackArea;
    [SerializeField] Transform skill1Area;
    SubMenuMain subMenu;
    Transform skill2Area;
    Transform skill3Area;
    //int playerMoveStateAnimator;
    int logint = 0;
    Rigidbody playerRigidbody;
    moveState playerMoveState; // 플레이어 움직임 상태
    State playerState;
    NavMeshAgent playerNavMeshAgent;
    Transform m_movePoint;
    MovePoint m_movePointScr;
    float moveTimeLook = 0f;
    bool isPause;
    enum moveState
    {
        none = 0,
        move
    }
    enum State
    {
        Idle,
        Move,
        Attack,
        Skill1,
        Skill2,
        Skill3
    }

    private void Start()
    {
        isPause = false;
        playerRigidbody = GetComponent<Rigidbody>();
        playerNavMeshAgent = GetComponent<NavMeshAgent>();
        playerState = State.Idle;
        playerinfo.SetPlayerInfo(100, 100, 10, 10);
        m_movePointScr = InGameSystem.Instance.GetMovePointObject().GetComponent<MovePoint>();
        subMenu = GameObject.Find("SubMenu").GetComponent<SubMenuMain>();
        //mainCamera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        moveTimeLook -= Time.deltaTime;
        if (moveTimeLook < 0)
            moveTimeLook = 0;
        if (InGameSystem.showSubMenu && InGameSystem.inGamePause)
        {
            if (isPause == false)
            {
                //playerNavMeshAgent.isStopped = true;
                //playerNavMeshAgent.velocity = Vector3.zero;
                playerAnimator.speed = 0f;
                isPause = true;
                return;
            }
        }
        if (InGameSystem.showSubMenu && InGameSystem.inGamePause)
        {
            if (isPause == true)
            {
                //playerNavMeshAgent.isStopped = false;
                playerAnimator.speed = 1f;
                isPause = false;
            }
        }
        if (logint != (int)playerState)
        {
            Debug.Log("playerState" + (int)playerState);
            logint = (int)playerState;
        }
       
        if (playerState<=State.Move) //재자리 또는 이동일때만 공격할때는 타면 안된다.
        {
            if (Input.GetMouseButton(1) && subMenu.CheckPointUI())
            {
                if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_idle_01")
                    ||playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_walk_01"))
                {
                    //playerNavMeshAgent.enabled = false;
                    Vector3 point = Scriptcode.GetWoldMousePoint();
                    transform.LookAt(new Vector3(point.x, 0, point.z));
                    attackArea.gameObject.SetActive(true);
                    ChangeState(State.Attack);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1) && subMenu.CheckPointUI()) //skill1
            {
                if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_idle_01")
                    || playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_walk_01"))
                {
                    //playerNavMeshAgent.enabled = false;
                    Vector3 point = Scriptcode.GetWoldMousePoint();
                    transform.LookAt(new Vector3(point.x, 0, point.z));
                    ChangeState(State.Skill1);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && subMenu.CheckPointUI()) //skill2
            {
                if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_idle_01")
                    || playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_walk_01"))
                {
                    //playerNavMeshAgent.enabled = false;
                    Vector3 point = Scriptcode.GetWoldMousePoint();
                    transform.LookAt(new Vector3(point.x, 0, point.z));
                    attackArea.gameObject.SetActive(true);
                    ChangeState(State.Attack);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && subMenu.CheckPointUI()) //skill3
            {
                if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_idle_01")
                    || playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_walk_01"))
                {
                    //playerNavMeshAgent.enabled = false;
                    Vector3 point = Scriptcode.GetWoldMousePoint();
                    transform.LookAt(new Vector3(point.x, 0, point.z));
                    attackArea.gameObject.SetActive(true);
                    ChangeState(State.Attack);
                }
            }
        }
        if((int)playerState < (int)State.Attack) //공격이 아닐때 움직인다.
        {
            //이동 우선 순위 키보드 -> 마우스
            /*
            Vector3 playerMove = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime,
                                             0,
                                             Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
            //playerNavMeshAgent.speed = 50f * moveSpeed * Time.deltaTime; //키보드 이동과 속도 동일화
            if (playerMove != Vector3.zero)
            {
                playerRigidbody.MovePosition(transform.position + playerMove);
                playerNavMeshAgent.enabled = false;
                ChangeState(State.Move);
            }
            else if (Input.GetMouseButton(0) && subMenu.CheckPointUI())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                playerNavMeshAgent.enabled = true;
                if (Physics.Raycast(ray, out RaycastHit raycastHit, 100f, layerMask))
                {
                    playerNavMeshAgent.destination = new Vector3(raycastHit.point.x, 0, raycastHit.point.z);
                    Debug.Log(playerNavMeshAgent.destination.x +" , "+ playerNavMeshAgent.destination.y + " , " + playerNavMeshAgent.destination.z);
                }
                ChangeState(State.Move);
            }
            else if (playerNavMeshAgent.enabled == true && playerNavMeshAgent.remainingDistance != 0) //도착전
            {
                ChangeState(State.Move);
            }
            else
            {
                ChangeState(State.Idle);
            }
            */
            if (Input.GetMouseButton(0) && moveTimeLook == 0 && subMenu.CheckPointUI() )
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //playerNavMeshAgent.enabled = true;
                if (Physics.Raycast(ray, out RaycastHit raycastHit, 100f, layerMask))
                {
                    Vector3 hitpoint = raycastHit.point;
                    hitpoint.y = 0;
                    SetMovePoint(hitpoint);
                }
                moveTimeLook = 0.02f;
            }
            Move();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerinfo.AddItems(1001);
            playerinfo.AddItems(1002);
            playerinfo.AddItems(1003);  
            playerinfo.AddItems(1004);
            playerinfo.AddItems(3001);
            playerinfo.AddItems(4001);
            playerinfo.AddItems(5001);
        }
    }

    public PlayerInfo GetPlayerInfo()
    {
        return playerinfo;
    }
    private void ChangeState(State state)
    {
        playerState = state;
        playerAnimator.SetInteger("State", (int)playerState);
    }
    public void AnimatorEnd()
    {   
        ChangeState(State.Idle);
    }
    public void TriggerOn()
    {
        if (playerState == State.Skill1)
        {
            skill1Area.gameObject.SetActive(true);
        }
    }
    public void AttackStart()
    {
        if (playerState == State.Attack)
        {
            NomalAttak nomalAttak = attackArea.GetComponent<NomalAttak>();
            nomalAttak.AttackStart();
        }
    }

    public void TriggerEnd()
    {
        if (playerState == State.Attack)
        {
            NomalAttak nomalAttak = attackArea.GetComponent<NomalAttak>();
            nomalAttak.TriggerEnd();
        }
        else if (playerState == State.Skill1)
        {
            SkillAttack skillAttack = skill1Area.GetComponent<SkillAttack>();
            skillAttack.TriggerEnd();
        }
    }

    private void SetMovePoint(Vector3 movepoint)
    {
        m_movePoint = m_movePointScr.ShowPoint(movepoint);
    }

    private void Move()
    {
        if (m_movePoint == null)
            return;
        ChangeState(State.Move);

        float f_move = moveSpeed*Time.deltaTime;
        Vector3 move_vector =  m_movePoint.position;
        Vector3 trans_vector = playerRigidbody.position;
        move_vector.y = 0;
        trans_vector.y = 0;
        Vector3 look_vector = m_movePoint.position;
        look_vector.y = transform.position.y;
        transform.LookAt(look_vector);
        if (f_move > Vector3.Distance(move_vector, trans_vector))
        {
            playerRigidbody.MovePosition(m_movePoint.position);
        }
        else
        {
            playerRigidbody.MovePosition(playerRigidbody.position + (transform.forward * f_move));
            Debug.Log("f_move : "+f_move);
        }

        if (m_movePoint.position.x == transform.position.x && m_movePoint.position.z == transform.position.z)
        {
            m_movePoint.GetComponent<MovePoint>().HidePoint();
            m_movePoint = null;
            ChangeState(State.Idle);
        }
    }

    public void Hit()
    {
        
    }
}