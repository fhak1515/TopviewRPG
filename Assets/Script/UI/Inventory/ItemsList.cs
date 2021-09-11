using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    public class Item_count
    {
        public int itemcode = 0;
        public int itemCount = 0;

        public Item_count(int itemcode, int itemCount)
        {
            this.itemcode = itemcode;
            this.itemCount = itemCount;
        }
    }
    public class Iteminfo_s
    {
        public int attack, deffend, usetype, gold;
        public float number;
        
        public string name, info;

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

    ItemsList() // 천 -> 무기 ; /name attack deffend usetype number info/
    {
        //itemsInfo.Add(0, new Iteminfo_s("",0,0,0,0,"",0));
        //무기
        itemsInfo.Add(1001, new Iteminfo_s("한손 검" ,5,0,0,1,"한손 검",10));
        itemsInfo.Add(1002, new Iteminfo_s("강철 검" ,7, 0, 0, 2, "강철 검", 50));
        itemsInfo.Add(1003, new Iteminfo_s("양손 검",10, 0, 0, 3, "양손 검", 100));
        itemsInfo.Add(1004, new Iteminfo_s("강철 대검",15,0,0,4,"강철 대검", 500));
        //방어구
        itemsInfo.Add(2001, new Iteminfo_s("녹슨 갑옷", 0,2,0,1,"녹슨 갑옷", 10));
        itemsInfo.Add(2002, new Iteminfo_s("평범한 갑옷", 0, 5, 0, 2, "평범한 갑옷", 50));
        itemsInfo.Add(2003, new Iteminfo_s("튼튼한 갑옷", 0, 7, 0, 3, "평범한 갑옷", 100));
        itemsInfo.Add(2004, new Iteminfo_s("대단한 갑옷", 0, 10, 0, 4, "평범한 갑옷", 500));

        //물약
        itemsInfo.Add(3001, new Iteminfo_s("체력 물약", 50, 0, 1, 1, "체력 물약", 25));
        itemsInfo.Add(3002, new Iteminfo_s("공격력 물약", 5, 0, 2, 2, "공격력 물약", 100));
        itemsInfo.Add(3003, new Iteminfo_s("방어력 물약", 3, 0, 3, 2, "방어력 물약", 100));

        //잡템
        itemsInfo.Add(4001, new Iteminfo_s("좀비 손", 0, 0, 0, 1, "좀비 손", 10));

        //퀘스트 템
        itemsInfo.Add(5001, new Iteminfo_s("좀비의 머리", 0, 0, 0, 1, "좀비의 머리", 0));
    }

    public Iteminfo_s FindItem(int itemcode)
    {
        return itemsInfo[itemcode];
    }
}
