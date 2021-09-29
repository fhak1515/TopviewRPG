using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Items : MonoBehaviour
{
    [SerializeField] Image itemimage;
    [SerializeField] Text itemcount;
    Canvas m_canvas;
    RectTransform recttransform;
    Vector3 nomalPositon;
    ItemsList itemsList;
    ItemsList.Item_count isItem;
    int m_indexNumber;
    int m_sortOrder;
    int m_itemType;
    public void ItemCodeAndCount(ItemsList.Item_count item)
    {
        isItem = item;
    }
    public void SettingItem(ItemsList.Item_count item , InventoryItems inventoryItems, int indexNumber)
    {
        isItem = item;
        m_itemType = inventoryItems.GetItemType();
        m_indexNumber = indexNumber;
        nomalPositon = transform.position;
        Debug.Log(transform.lossyScale);
    }
    public void SettingItem(ItemsList.Item_count item)
    {
        isItem = item;
        ItemSetting();
    }
    public void SetIndexNumber(int number)
    { 
        m_indexNumber = number;
    }
    public int GetIndexNumber()
    {
        return m_indexNumber;
    }
    public int GetCount()
    {
        return isItem.itemCount;
    }
    public Sprite GetItemSprite()
    {
        return itemimage.sprite;
    }
    private void Start()
    {
        //itemcode = 1001;
        m_canvas = GetComponent<Canvas>();
        m_sortOrder = m_canvas.sortingOrder;
        itemsList = InGameSystem.mainItemList;
        recttransform = GetComponent<RectTransform>();
        ItemSetting();
    }

    public int GetItemCode()
    {
        return isItem.itemcode;
    }
    public int GetItemType()
    {
        return m_itemType;
    }
    public ItemsList.Item_count GetItem()
    {
        return isItem;
    }
    public bool GetIsEqi()
    {
        return InGameSystem.mainPlayerInfo.CheckEqui(isItem);
    }

    public ItemsList.Item_count ChangeItemCode(ItemsList.Item_count item)
    {
        ItemsList.Item_count dumpitem = isItem;
        isItem = item;
        return dumpitem;
    }

    public void ItemSetting()
    {
        if (isItem.itemcode != 0)
        {
            if (itemsList.FindItem(isItem.itemcode) == null)
            {
                Debug.Log("ItemsNULL");
                isItem.SetItemCode(0);
                itemimage.enabled = false;
                return;
            }
            int itemtype; //1 무기 2 방어구 3 소비아이템 4 잡템 5 퀘스트템
            itemtype = isItem.itemcode / 1000;
            Debug.Log("ItemsImageLoad");
            switch (itemtype)
            {
                case 1:
                    itemimage.sprite = Resources.Load<Sprite>("Image/Items/Weapon/" + isItem.itemcode % 1000);
                    break;
                case 2:
                    itemimage.sprite = Resources.Load<Sprite>("Image/Items/Armo/" + isItem.itemcode % 1000);
                    break;
                case 3:
                    itemimage.sprite = Resources.Load<Sprite>("Image/Items/UseItme/" + isItem.itemcode % 1000);
                    itemcount.text = isItem.itemCount.ToString();
                    itemcount.enabled = true;
                    break;
                case 4:
                    itemimage.sprite = Resources.Load<Sprite>("Image/Items/NomalItem/" + isItem.itemcode % 1000);
                    itemcount.text = isItem.itemCount.ToString();
                    itemcount.enabled = true;
                    break;
                case 5:
                    itemimage.sprite = Resources.Load<Sprite>("Image/Items/QuestItem/" + isItem.itemcode % 1000);
                    itemcount.text = isItem.itemCount.ToString();
                    itemcount.enabled = true;
                    break;
            }
            Debug.Log("ItemsImageLoadSussese");
        }
        else
        {
            itemimage.sprite = null;
            itemimage.enabled = false;
            itemcount.enabled = false;
        }

        if (itemimage.sprite != null)
        {
            itemimage.enabled = true;
        }
    }
    public void SetItemBoxSucces()
    {
        nomalPositon = transform.position;
    }
    public void DragItem(Vector3 position)
    {
        position.x -= (recttransform .sizeDelta.x /2)* transform.lossyScale.x;
        position.y += (recttransform.sizeDelta.y / 2) * transform.lossyScale.y;
        position.z = 2;
        Debug.Log("DragItem");
        m_canvas.sortingOrder = m_sortOrder+1;
        transform.position = position;
    }
    public void PositionReset()
    {
        Debug.Log("PositionReset");
        m_canvas.sortingOrder = m_sortOrder;
        transform.position = nomalPositon;
    }

    public void ChangeItems(ItemsList.Item_count item)
    {
        isItem = item;
        PositionReset();
        ItemSetting();
    }
}
