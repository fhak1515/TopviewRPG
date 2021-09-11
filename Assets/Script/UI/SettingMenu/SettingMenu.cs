using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    bool otherSubMenuOn;
    SubMenuMain submenu;
    // Start is called before the first frame update
    void Start()
    {
        submenu = GameObject.Find("SubMenu").GetComponent<SubMenuMain>();
        submenu.SetUIObject(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void otherSubMenuOnCheck()
    {
        if (InGameSystem.showSubMenu)
        {
            otherSubMenuOn = true;
            return;
        }
        otherSubMenuOn = false;
    }

    public void OnClickReturnButton()
    {
        if (!otherSubMenuOn)
            InGameSystem.showSubMenu = false;
        InGameSystem.inGamePause = false;
        submenu.FindDeleteObejct(gameObject);
        Destroy(gameObject);
    }
}
