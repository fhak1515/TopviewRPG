using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    [SerializeField] Text itemName;
    [SerializeField] Text state;
    [SerializeField] Text info;
    [SerializeField] Image itemImage;
    [SerializeField] Text isEiq;
    public void SetItem(Items item)
    {
        int itemNumber = item.GetItemCode();
        ItemsList.Iteminfo_s finditeminfo = InGameSystem.mainItemList.FindItem(itemNumber);

        itemName.text = finditeminfo.name;
        if (item.GetItemType() != 1)
            state.text = "갯수 : " +  item.GetCount().ToString();
        else
        {
            if (finditeminfo.attack == 0)
            {
                state.text = "방어력 : " + finditeminfo.deffend;
            }
            else
            {
                state.text = "공격력 : " + finditeminfo.attack;
            }

            if (item.GetIsEqi())
                isEiq.gameObject.SetActive(true);
            else
                isEiq.gameObject.SetActive(false);
        }

        info.text = finditeminfo.info;
        itemImage.sprite = item.GetItemSprite();
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
}
