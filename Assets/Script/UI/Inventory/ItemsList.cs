using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    public class Item_count
    {
        public int itemcode { protected set; get; }
        public int itemCount { protected set; get; }

        public Item_count(int itemcode, int itemCount)
        {
            this.itemcode = itemcode;
            this.itemCount = itemCount;
        }
        public void SetItemCode(int itemcode)
        {
            this.itemcode = itemcode;
        }
        public void Items_coutPluse(int itemCount)
        {
            this.itemCount += itemCount;
        }
    }
    public class Iteminfo_s
    {
        public int attack { protected set; get; }
        public int deffend { protected set; get; }
        public int usetype { protected set; get; }
        public int gold { protected set; get; }
        public float number { protected set; get; }

        public string name { protected set; get; }
        public string info { protected set; get; }

        public Iteminfo_s(string name,int attack, int deffend, int usetype, float number, string info, int gold)
        {
            this.name = name;
            this.attack = attack;
            this.deffend = deffend;
            this.usetype = usetype;
            this.number = number;
            this.info = info;
            this.gold = gold;
        }
    }
    
    Dictionary<int, Iteminfo_s> itemsInfo = new Dictionary<int, Iteminfo_s>();

    ItemsList() // Ãµ -> ¹«±â ; /name attack deffend usetype number info/
    {
        //itemsInfo.Add(0, new Iteminfo_s("",0,0,0,0,"",0));
        //¹«±â
        itemsInfo.Add(1001, new Iteminfo_s("ÇÑ¼Õ °Ë" ,5,0,0,1,"ÇÑ¼Õ °Ë",10));
        itemsInfo.Add(1002, new Iteminfo_s("°­Ã¶ °Ë" ,7, 0, 0, 2, "°­Ã¶ °Ë", 50));
        itemsInfo.Add(1003, new Iteminfo_s("¾ç¼Õ °Ë",10, 0, 0, 3, "¾ç¼Õ °Ë", 100));
        itemsInfo.Add(1004, new Iteminfo_s("°­Ã¶ ´ë°Ë",15,0,0,4,"°­Ã¶ ´ë°Ë", 500));
        //¹æ¾î±¸
        itemsInfo.Add(2001, new Iteminfo_s("³ì½¼ °©¿Ê", 0,2,0,1,"³ì½¼ °©¿Ê", 10));
        itemsInfo.Add(2002, new Iteminfo_s("Æò¹üÇÑ °©¿Ê", 0, 5, 0, 2, "Æò¹üÇÑ °©¿Ê", 50));
        itemsInfo.Add(2003, new Iteminfo_s("Æ°Æ°ÇÑ °©¿Ê", 0, 7, 0, 3, "Æò¹üÇÑ °©¿Ê", 100));
        itemsInfo.Add(2004, new Iteminfo_s("´ë´ÜÇÑ °©¿Ê", 0, 10, 0, 4, "Æò¹üÇÑ °©¿Ê", 500));

        //¹°¾à
        itemsInfo.Add(3001, new Iteminfo_s("Ã¼·Â ¹°¾à", 50, 0, 1, 1, "Ã¼·Â ¹°¾à", 25));
        itemsInfo.Add(3002, new Iteminfo_s("°ø°Ý·Â ¹°¾à", 5, 0, 2, 2, "°ø°Ý·Â ¹°¾à", 100));
        itemsInfo.Add(3003, new Iteminfo_s("¹æ¾î·Â ¹°¾à", 3, 0, 3, 2, "¹æ¾î·Â ¹°¾à", 100));

        //ÀâÅÛ
        itemsInfo.Add(4001, new Iteminfo_s("Á»ºñ ¼Õ", 0, 0, 0, 1, "Á»ºñ ¼Õ", 10));

        //Äù½ºÆ® ÅÛ
        itemsInfo.Add(5001, new Iteminfo_s("Á»ºñÀÇ ¸Ó¸®", 0, 0, 0, 1, "Á»ºñÀÇ ¸Ó¸®", 0));
    }

    public Iteminfo_s FindItem(int itemcode)
    {
        return itemsInfo[itemcode];
    }
}
