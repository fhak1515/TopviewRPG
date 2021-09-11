using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject itemInfo;
    PlayerInfo playerinfo;
    SubMenuMain submenu;
    void Start()
    {
        submenu = GameObject.Find("SubMenu").GetComponent<SubMenuMain>();
        playerinfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        submenu.SetUIObject(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (InGameSystem.inGamePause)
        {
            return;
        }
    }

    void ShowItemInfo(int itemcode)
    {
        itemInfo.transform.position = Input.mousePosition + new Vector3(5, -5);
    }
    public void InventoryExit()
    {
        //transform.GetComponent<Canvas>().enabled = false;
        InGameSystem.showSubMenu = false;
        submenu.FindDeleteObejct(gameObject);
        Destroy(gameObject);
    }
    public PlayerInfo GetPlayerInfo()
    {
        if (playerinfo == null)
        {
            playerinfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        }
        return playerinfo;
    }
}
