using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItems : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] int itemtype; //1 장비 2 소비 3 잡템 4 퀘스트
    PlayerInfo playerinfo;
    List<GameObject> items = new List<GameObject>();
    List<ItemsList.Item_count> itemcodelist;
    RectTransform itemsStartPoint;
    int changeLine1; //드래그앤 드롭으로 자리 변경 시 해당 위치 값
    int changeLine2;
    private void Start()
    {
        itemsStartPoint = transform.Find("ItemPoint").GetComponent<RectTransform>();
        playerinfo = InGameSystem.mainPlayerInfo;
        itemcodelist = playerinfo.GetItemList(itemtype);
        if (itemcodelist == playerinfo.GetItemList(itemtype))
        {
            Debug.Log("Pointer Same");
        }
        MakeItems();
    }

    void MakeItems()
    {
        for (int a =0; a < itemcodelist.Count; a++)
        {
            GameObject item = Resources.Load<GameObject>("Prefab/UI/InventoryItem");
            GameObject thisitem = Instantiate(item, this.transform);
            thisitem.GetComponent<Items>().ItemCodeAndCount(itemcodelist[a]);
            thisitem.GetComponent<Items>().listNumber = items.Count;
            items.Add(thisitem);
            float x = itemsStartPoint.localPosition.x;
            float y = itemsStartPoint.localPosition.y;
            float sizex = itemsStartPoint.sizeDelta.x;
            float sizey = itemsStartPoint.sizeDelta.y;

            thisitem.GetComponent<RectTransform>().localPosition = itemsStartPoint.localPosition;
            thisitem.GetComponent<RectTransform>().sizeDelta = itemsStartPoint.sizeDelta;
            thisitem.GetComponent<RectTransform>().localPosition += new Vector3((x + sizex) * (a % 7), (y - sizey) * (a / 7));
        }
    }
    int NoItemsCount(out int line)
    {
        line = -1;
        int count = 0;
        for (int a = 0; a<items.Count; a++)
        {
            int code = items[a].GetComponent<Items>().GetItemCode();
            if (code == 0)
            {
                count++;
                line = a;
            }
        }
        return count;
    }

    public bool AddItems(int itemcode)
    {
        int line;
        if ( NoItemsCount(out line) != 0)
        {
            Debug.Log(line);
            return true;
        }
        return false;
    }
}
