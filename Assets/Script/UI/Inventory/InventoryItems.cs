using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItems : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] int itemtype; //1 ��� 2 �Һ� 3 ���� 4 ����Ʈ
    PlayerInfo playerinfo;
    List<GameObject> items = new List<GameObject>();
    List<ItemsList.Item_count> itemcodelist;
    int changeLine1; //�巡�׾� ������� �ڸ� ���� �� �ش� ��ġ ��
    int changeLine2;
    private void Start()
    {
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
            thisitem.GetComponent<RectTransform>().position += new Vector3(47 * (a % 7), -47 * (a / 7));
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
