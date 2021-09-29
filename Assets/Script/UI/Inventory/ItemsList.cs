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

    ItemsList() // õ -> ���� ; /name attack deffend usetype number info/
    {
        //itemsInfo.Add(0, new Iteminfo_s("",0,0,0,0,"",0));
        //����
        itemsInfo.Add(1001, new Iteminfo_s("�Ѽ� ��" ,5,0,0,1,"�Ѽ� ��",10));
        itemsInfo.Add(1002, new Iteminfo_s("��ö ��" ,7, 0, 0, 2, "��ö ��", 50));
        itemsInfo.Add(1003, new Iteminfo_s("��� ��",10, 0, 0, 3, "��� ��", 100));
        itemsInfo.Add(1004, new Iteminfo_s("��ö ���",15,0,0,4,"��ö ���", 500));
        //��
        itemsInfo.Add(2001, new Iteminfo_s("�콼 ����", 0,2,0,1,"�콼 ����", 10));
        itemsInfo.Add(2002, new Iteminfo_s("����� ����", 0, 5, 0, 2, "����� ����", 50));
        itemsInfo.Add(2003, new Iteminfo_s("ưư�� ����", 0, 7, 0, 3, "����� ����", 100));
        itemsInfo.Add(2004, new Iteminfo_s("����� ����", 0, 10, 0, 4, "����� ����", 500));

        //����
        itemsInfo.Add(3001, new Iteminfo_s("ü�� ����", 50, 0, 1, 1, "ü�� ����", 25));
        itemsInfo.Add(3002, new Iteminfo_s("���ݷ� ����", 5, 0, 2, 2, "���ݷ� ����", 100));
        itemsInfo.Add(3003, new Iteminfo_s("���� ����", 3, 0, 3, 2, "���� ����", 100));

        //����
        itemsInfo.Add(4001, new Iteminfo_s("���� ��", 0, 0, 0, 1, "���� ��", 10));

        //����Ʈ ��
        itemsInfo.Add(5001, new Iteminfo_s("������ �Ӹ�", 0, 0, 0, 1, "������ �Ӹ�", 0));
    }

    public Iteminfo_s FindItem(int itemcode)
    {
        return itemsInfo[itemcode];
    }
}
