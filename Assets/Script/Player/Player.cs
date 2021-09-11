using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Camera mainCamera;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Animator playerAnimator;
    [SerializeField] PlayerInfo playerinfo;
    [SerializeField] Transform attackArea;
    [SerializeField] Transform skill1Area;
    [SerializeField] SubMenuMain subMenu;
    Transform skill2Area;
    Transform skill3Area;
    //int playerMoveStateAnimator;
    int logint = 0;
    Rigidbody playerRigidbody;
    Vector3 movePoint;
    moveState playerMoveState; // �÷��̾� ������ ����
    State playerState;
    NavMeshAgent playerNavMeshAgent;
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
        //mainCamera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        if (InGameSystem.showSubMenu && InGameSystem.inGamePause)
        {
            if (isPause == false)
            {
                playerNavMeshAgent.isStopped = true;
                playerNavMeshAgent.velocity = Vector3.zero;
                playerAnimator.speed = 0f;
                isPause = true;
                return;
            }
        }
        if (InGameSystem.showSubMenu && InGameSystem.inGamePause)
        {
            if (isPause == true)
            {
                playerNavMeshAgent.isStopped = false;
                playerAnimator.speed = 1f;
                isPause = false;
            }
        }
        if (logint != (int)playerState)
        {
            Debug.Log("playerState" + (int)playerState);
            logint = (int)playerState;
        }
       
        if (playerState<=State.Move) //���ڸ� �Ǵ� �̵��϶��� �����Ҷ��� Ÿ�� �ȵȴ�.
        {
            if (Input.GetMouseButton(1))
            {
                if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_idle_01")
                    ||playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_walk_01"))
                {
                    playerNavMeshAgent.enabled = false;
                    Vector3 point = Scriptcode.GetWoldMousePoint();
                    transform.LookAt(new Vector3(point.x, 0, point.z));
                    attackArea.gameObject.SetActive(true);
                    ChangeState(State.Attack);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1)) //skill1
            {
                if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_idle_01")
                    || playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_walk_01"))
                {
                    playerNavMeshAgent.enabled = false;
                    Vector3 point = Scriptcode.GetWoldMousePoint();
                    transform.LookAt(new Vector3(point.x, 0, point.z));
                    ChangeState(State.Skill1);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) //skill2
            {
                if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_idle_01")
                    || playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_walk_01"))
                {
                    playerNavMeshAgent.enabled = false;
                    Vector3 point = Scriptcode.GetWoldMousePoint();
                    transform.LookAt(new Vector3(point.x, 0, point.z));
                    attackArea.gameObject.SetActive(true);
                    ChangeState(State.Attack);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) //skill3
            {
                if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_idle_01")
                    || playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("arthur_walk_01"))
                {
                    playerNavMeshAgent.enabled = false;
                    Vector3 point = Scriptcode.GetWoldMousePoint();
                    transform.LookAt(new Vector3(point.x, 0, point.z));
                    attackArea.gameObject.SetActive(true);
                    ChangeState(State.Attack);
                }
            }
        }
        if((int)playerState < (int)State.Attack) //������ �ƴҶ� �����δ�.
        {
            //�̵� �켱 ���� Ű���� -> ���콺
            Vector3 playerMove = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime,
                                             0,
                                             Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
            playerNavMeshAgent.speed = 50f * moveSpeed * Time.deltaTime; //Ű���� �̵��� �ӵ� ����ȭ
            if (playerMove != Vector3.zero)
            {
                playerRigidbody.MovePosition(transform.position + playerMove);
                playerNavMeshAgent.enabled = false;
                ChangeState(State.Move);
            }
            else if (Input.GetMouseButton(0) && subMenu.CheckPointUI())
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                playerNavMeshAgent.enabled = true;
                if (Physics.Raycast(ray, out RaycastHit raycastHit, 100f, layerMask))
                {
                    playerNavMeshAgent.destination = raycastHit.point;
                    Debug.Log(raycastHit.point.x +" , "+raycastHit.point.y + " , " + raycastHit.point.z);
                }
                ChangeState(State.Move);
            }
            else if (playerNavMeshAgent.enabled == true && playerNavMeshAgent.remainingDistance != 0) //������
            {
                ChangeState(State.Move);
            }
            else
            {
                ChangeState(State.Idle);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerinfo.AddItems(1001);
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
}