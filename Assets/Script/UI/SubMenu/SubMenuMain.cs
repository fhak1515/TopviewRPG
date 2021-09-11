using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMenuMain : MonoBehaviour
{
    bool showathormenu = false;
    GameObject settingMenu;
    [SerializeField]List<GameObject> objects;
    [SerializeField] Text inventoryfull;
    [SerializeField] Text hp;
    [SerializeField] Text mp;
    string s_hp;
    string s_mp;
    Coroutine showinventoryfull;
    private void Start()
    {
        s_hp = hp.text;
        s_mp = mp.text;
    }

    private void Update()
    {
        if (InGameSystem.mainPlayerInfo)
        {
            hp.enabled = true;
            hp.enabled = true;
            hp.text = s_hp+InGameSystem.mainPlayerInfo.hp.ToString()+" / "+ InGameSystem.mainPlayerInfo.maxHp.ToString();
            mp.text = s_mp+InGameSystem.mainPlayerInfo.mp.ToString()+" / "+ InGameSystem.mainPlayerInfo.maxMp.ToString();
        }
        else
        {
            hp.enabled = false;
            mp.enabled = false;
        }
    }
    public void OnClickInventoryButton()
    {
        if (!InGameSystem.showSubMenu)
        {
            Instantiate(Resources.Load<GameObject>("Prefab/UI/Inventory"));
            InGameSystem.showSubMenu = true;
        }
    }
    public void OnClickSettingButton()
    {
        if (!settingMenu)
        {
            settingMenu = Instantiate(Resources.Load<GameObject>("Prefab/UI/SettingMenu"));
            settingMenu.GetComponent<SettingMenu>().otherSubMenuOnCheck();
            InGameSystem.showSubMenu = true;
            InGameSystem.inGamePause = true;
        }
    }
    public bool CheckPointUI()
    {
        Vector3 mousepoint = Input.mousePosition;

        for (int a = 0; a< objects.Count; a++)
        {
            float x = objects[a].transform.position.x;
            float y = objects[a].transform.position.y;
            Vector2 size = objects[a].GetComponent<RectTransform>().sizeDelta;

            if (mousepoint.x >= x - (size.x / 2) && mousepoint.x <= x + (size.x / 2))
            {
                if (mousepoint.y >= y - (size.y / 2) && mousepoint.y <= y + (size.y / 2))
                {
                    Debug.Log("check false");
                    return false;
                }
            }
        }
        Debug.Log("check ture");
        return true;
    }

    public void SetUIObject(GameObject uiobject)
    {
        objects.Add(uiobject);
    }

    public void FindDeleteObejct(GameObject uiobject)
    {
        Debug.Log(objects.Count);
        objects.Remove(uiobject);
        Debug.Log(objects.Count);
    }

    public void InventoryFull()
    {
        if (showinventoryfull == null) {
            showinventoryfull = StartCoroutine(ShowInventoryFull());
        }
        else
        {
            StopCoroutine(showinventoryfull);
            showinventoryfull = StartCoroutine(ShowInventoryFull());
        }

    }
    IEnumerator ShowInventoryFull()
    {
        inventoryfull.enabled = true;
        yield return new WaitForSeconds(1.2f);
        inventoryfull.enabled = false;
    }
}
