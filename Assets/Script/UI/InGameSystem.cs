using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSystem : MonoBehaviour
{
    public static InGameSystem Instance;
    public static bool showSubMenu = false; //���� �޴�
    public static bool inGamePause = false; //���� ����
    public static float inGameSound = 1f;
    public static bool gameStart = true; //���� ���� (�÷��̾� ĳ�� ���� ��)
    public static PlayerInfo mainPlayerInfo; //���� �÷��̾� ����
    public static GameObject mainPlayer; //���� �÷��̾�
    public static SubMenuMain mainSubMenu;
    public static ItemsList mainItemList;
    [SerializeField]GameObject movePoint;
    InGameSystem()
    {
        InGameSystem.Instance = this;
    }

    private void Start()
    {
        mainItemList = GetComponent<ItemsList>();
        GameStartSetting();
    }
    private void Update()
    {
        GameStartSetting();
    }

    void GameStartSetting()
    {
        if (gameStart) //���� ���� ���� ��� ����
        {
            if (!mainPlayerInfo)
                mainPlayerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
            if (!mainPlayer)
                mainPlayer = GameObject.Find("Player");
            if (!mainSubMenu)
                mainSubMenu = GameObject.Find("SubMenu").GetComponent<SubMenuMain>();
        }
    }
    public GameObject GetMovePointObject()
    {
        return movePoint;
    }
}
