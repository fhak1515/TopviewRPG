using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    [SerializeField] Image itemimage;
    [SerializeField] Text itemcount;
    Vector3 nomalPositon;
    ItemsList itemsList;
    ItemsList.Item_count isItem;
    public int listNumber;
    bool isChange = false;
    
    public void ItemCodeAndCount(ItemsList.Item_count item)
    {
        isItem = item;
    }
    
    private void Start()
    {
        //itemcode = 1001;
        itemsList = GameObject.Find("InGame").GetComponent<ItemsList>();
        ItemSetting();
    }
    private void Update()
    {
        if (isChange)
        {
            ItemSetting();
        }
    }

    public int GetItemCode()
    {
        return isItem.itemcode;
    }

    public ItemsList.Item_count ChangeItemCode(ItemsList.Item_count item)
    {
        ItemsList.Item_count dumpitem = isItem;
        isItem = item;
        isChange = true;
        return dumpitem;
    }

    void ItemSetting()
    {
        if (isItem.itemcode != 0)
        {
            if (itemsList.FindItem(isItem.itemcode) == null)
            {
                Debug.Log("ItemsNULL");
                isItem.itemcode = 0;
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

        if (itemimage.sprite != null)
        {
            itemimage.enabled = true;
        }
    }
    public void SetItemBoxSucces()
    {
        nomalPositon = transform.position;
    }


}
