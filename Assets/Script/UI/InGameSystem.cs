using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSystem : MonoBehaviour
{
    public static InGameSystem Instance;
    public static bool showSubMenu = false; //서브 메뉴
    public static bool inGamePause = false; //게임 정지
    public static float inGameSound = 1f;
    public static bool gameStart = true; //게임 시작 (플레이어 캐릭 선택 후)
    public static PlayerInfo mainPlayerInfo; //메인 플레이어 정보
    public static GameObject mainPlayer; //메인 플레이어
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
        if (gameStart) //게임 시작 중일 경우 셋팅
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
