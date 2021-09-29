using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventoryItems : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] int itemtype; //1 장비 2 소비 3 잡템 4 퀘스트
    [SerializeField] RectTransform itemsStartPoint;
    [SerializeField] Transform main;
    [SerializeField] InventorySubMenu submenu;
    [SerializeField] ItemInfoMain itemInfoMain;
    PlayerInfo playerinfo;
    List<GameObject> items = new List<GameObject>();
    List<ItemsList.Item_count> itemcodelist;
    Canvas canvas;
    RectTransform rectTransform;
    int changeLine1; //드래그앤 드롭으로 자리 변경 시 해당 위치 값
    int changeLine2;
    float itemStartx = 0f;
    float itemStarty = 0f;
    float sizex = 0f;
    float sizey = 0f;
    float waitTime;
    float itemClickTime;
    bool isDragItem;
    int isDragItemsIndex;
    int itemIndex;
    int waitIndex;
    bool canvasInPoint;
    bool m_showSubmenu;

    private void Start()
    {
        //itemsStartPoint = transform.Find("ItemPoint").GetComponent<RectTransform>();
        canvasInPoint = false;
        m_showSubmenu = false;
        canvas = GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        itemStartx = itemsStartPoint.localPosition.x;
        itemStarty = itemsStartPoint.localPosition.y;
        sizex = itemsStartPoint.sizeDelta.x;
        sizey = itemsStartPoint.sizeDelta.y;
        itemIndex = -1;
        isDragItemsIndex = -1;
        itemClickTime = 0;
        playerinfo = InGameSystem.mainPlayerInfo;
        itemcodelist = playerinfo.GetItemList(itemtype);
        if (itemcodelist == playerinfo.GetItemList(itemtype))
        {
            Debug.Log("Pointer Same");
        }
        MakeItems();
        isDragItem = false;
        waitTime = 0;
        waitIndex = -1;
    }
    public int GetItemType()
    {
        return itemtype;
    }
    private void OnDisable()
    {
        itemIndex = -1;
        isDragItemsIndex = -1;
        itemClickTime = 0;
        waitTime = 0;
        waitIndex = -1;
        canvasInPoint = false;
        m_showSubmenu = false;
        submenu.HideSubMenu();
        HideItemsInfo();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !submenu.CheckPointIn(Input.mousePosition))
        {
            if (m_showSubmenu)
            {
                submenu.HideSubMenu();
                m_showSubmenu = false;
            }
            else
            {
                HideItemsInfo();
                MouseDownEvent(MousePointIndex(Input.mousePosition));
            }
        }
        else if (Input.GetMouseButton(0) && !submenu.CheckPointIn(Input.mousePosition))
        {
            if (InCanvas(Input.mousePosition))
            {
                MouseClickEvent(MousePointIndex(Input.mousePosition));
            }
        }
        else if (Input.GetMouseButtonUp(0) && !submenu.CheckPointIn(Input.mousePosition))
        {
            if (InCanvas(Input.mousePosition))
            {
                MouseUpEvent(MousePointIndex(Input.mousePosition));
            }
        }
        // 오른쪽 마우스
        else if (Input.GetMouseButtonDown(1))
        {
            itemIndex = MousePointIndex(Input.mousePosition);
            if (itemIndex != -1 && items[itemIndex].GetComponent<Items>().GetItemCode() !=0)
            {
                HideItemsInfo();
                m_showSubmenu = true;
                submenu.ShowSubMenu(Input.mousePosition, itemIndex);
            }
        }else
        {
            if (InCanvas(Input.mousePosition))
            {
                int indexnumver = MousePointIndex(Input.mousePosition);
                if (indexnumver != -1)
                {
                    if (indexnumver != waitIndex)
                    {
                        HideItemsInfo();
                        waitIndex = indexnumver;
                    }
                    waitTime += Time.deltaTime;
                    if (waitTime >= 0.3f)
                    {
                        itemInfoMain.ShowItemInfoMain(items[waitIndex].GetComponent<Items>());
                    }
                }
                else
                {
                    HideItemsInfo();
                }
            }
            else
            {
                HideItemsInfo();
            }
        }
        //ClickEvent();
    }
    void HideItemsInfo()
    {
        if (itemInfoMain.gameObject.activeInHierarchy)
        {
            itemInfoMain.HideItemInfoMain();
        }
        waitIndex = -1;
        waitTime = 0f;
    }

    void MakeItems()
    {
        for (int a =0; a < itemcodelist.Count; a++)
        {
            GameObject item = Resources.Load<GameObject>("Prefab/UI/InventoryItem");
            GameObject thisitem = Instantiate(item, this.transform);
            RectTransform itemRect= thisitem.GetComponent<RectTransform>();
            itemRect.localPosition = itemsStartPoint.localPosition;
            itemRect.sizeDelta = itemsStartPoint.sizeDelta;
            itemRect.localPosition += new Vector3((itemStartx + sizex) * (a % 7), (itemStarty - sizey) * (a / 7));

            thisitem.GetComponent<Items>().SettingItem(itemcodelist[a], this, items.Count);
            items.Add(thisitem);
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

    void MouseClickEvent(int index)
    {
        if (index != -1)
        {
            Debug.Log("Input");
            if (!isDragItem)
            {
                if (isDragItemsIndex == index)
                {
                    itemClickTime += Time.deltaTime;
                }
                else
                {
                    isDragItemsIndex = index;
                    itemClickTime = 0;
                }

                if (itemClickTime >= 0.05)
                {
                    isDragItem = true;
                }
            }
            if (isDragItem)
            {
                items[isDragItemsIndex].GetComponent<Items>().DragItem(Input.mousePosition);
            }
        }
    }
    void MouseDownEvent(int index)
    {
        Debug.Log("ClickDown : " + index);
    }
    void MouseUpEvent(int index)
    {
        if (isDragItem)
        {
            if (index != -1 && isDragItemsIndex != itemIndex)
            {
                ItemsList.Item_count dragitem = itemcodelist[isDragItemsIndex];
                items[isDragItemsIndex].GetComponent<Items>().ChangeItems(itemcodelist[index]);
                items[index].GetComponent<Items>().ChangeItems(dragitem);
                itemcodelist[isDragItemsIndex] = itemcodelist[index];
                itemcodelist[index] = dragitem;
            }
            else
            {
                items[isDragItemsIndex].GetComponent<Items>().PositionReset();
            }
            itemClickTime = 0;
            isDragItem = false;
        }
    }
    public void NowItemIndex(int index)
    {
        Debug.Log("NowItemIndex");
        itemIndex = index;
    }
    public void NowItemInexExit()
    {
        Debug.Log("NowItemInexExit");
        if (!isDragItem)
        {
            itemClickTime = 0;
        }
        itemIndex = -1;
    }

    public void SetCanvasInPoint(bool value)
    {
        Debug.Log("SetCanvasInPoint");
        canvasInPoint = value;
    }
    public int compare(ItemsList.Item_count x, ItemsList.Item_count y)

    {
        if (x.itemcode ==y.itemcode)
            return 0;
        if (x.itemcode > y.itemcode)
            return -1;

        return 1;
    }

    public void SortItems()
    {
        Debug.Log("Sort Start");
        itemcodelist.Sort(compare);
        Debug.Log("Sort End");
        for (int a= 0; a < itemcodelist.Count; a++)
        {
            items[a].GetComponent<Items>().SettingItem(itemcodelist[a]);
        }
    }
    public int MousePointIndex(Vector3 point)
    {
        Vector3 mouse = point;
        mouse -= rectTransform.position;
        int index = -1;
        Vector3 startpoint = itemsStartPoint.position - rectTransform.position;
        Debug.Log("MousePoint " + mouse);
        Debug.Log("Point "+ startpoint);
        Debug.Log("size " + itemsStartPoint.sizeDelta* main.lossyScale);
        

        index = (int)(mouse.x / (startpoint.x + (itemsStartPoint.sizeDelta.x * main.lossyScale.x)) +
            (int)(mouse.y / (startpoint.y - (itemsStartPoint.sizeDelta.y * main.lossyScale.y))) *7);

        Debug.Log("index : "+ index);


        if (index < 0 || index >= items.Count)
            index = -1;

        return index;
    }
    bool InCanvas(Vector3 point)
    {
        Vector3 mouse = point;
        mouse -= rectTransform.position;

        if (0 <= mouse.x && rectTransform.sizeDelta.x * main.localScale.x >= mouse.x
            && 0 >= mouse.y && -rectTransform.sizeDelta.y * main.localScale.y <= mouse.y)
        {
            Debug.Log("In");
            return true;
        }
        else
        {
            Debug.Log("Out");
            return false;
        }
    }

    public void Equip()
    {
        Debug.Log("Equip");
        ItemsList.Item_count item = items[itemIndex].GetComponent<Items>().GetItem();
        if (item.itemcode >= 1000 && item.itemcode < 2000)
        {
            Debug.Log("SetWeapon");
            playerinfo.SetWeapon(item, itemIndex);
        }else if (item.itemcode >= 2000 && item.itemcode < 3000)
        {
            Debug.Log("SetArmo");
            playerinfo.SetArmo(item, itemIndex);
        }
        HideItemsInfo();
    }
    public void Use()
    {
        Debug.Log("Use");
    }
    public void Sell()
    {
        if (items[itemIndex].GetComponent<Items>().GetItem() == playerinfo.EquiWeapon())
        {
            Debug.Log("장착 중인 장비입니다.");
            return;
        }

        Debug.Log("Sell");
        ItemsList.Item_count item = items[itemIndex].GetComponent<Items>().GetItem();
        ItemsList.Iteminfo_s iteminfo = InGameSystem.mainItemList.FindItem(item.itemcode);

        //판매 금액 -> 인벤토리 + 판매금
        Debug.Log("SellCount : "+ item.itemCount);
        InGameSystem.mainPlayerInfo.PlusGold(iteminfo.gold * item.itemCount);
        

        item.SetItemCode(0);
        item.Items_coutPluse(-item.itemCount);
        items[itemIndex].GetComponent<Items>().ItemSetting();
        HideItemsInfo();
    }
    public void Out()
    {
        if (items[itemIndex].GetComponent<Items>().GetItem() == playerinfo.EquiWeapon())
        {
            Debug.Log("장착 중인 장비입니다.");
            return;
        }

        Debug.Log("Why Out");
        ItemsList.Item_count item = items[itemIndex].GetComponent<Items>().GetItem();

        item.SetItemCode(0);
        item.Items_coutPluse(-item.itemCount);
        items[itemIndex].GetComponent<Items>().ItemSetting();
        HideItemsInfo();
    }
}
