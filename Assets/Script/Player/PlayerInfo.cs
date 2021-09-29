using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int hp { get; private set; }
    public int maxHp { get; private set; }
    public int mp { get; private set; }
    public int maxMp { get; private set; }
    public int damage { get; private set; }
    public int arm { get; private set; }
    

    public int itemMaxHp { get; private set; }
    public int itmeMaxMp { get; private set; }
    public int itemDamage { get; private set; }
    public int itemArm { get; private set; }

    public int buffDamage { get; private set; }
    public int buffArm { get; private set; }
    public int gold;

    [SerializeField][Range(0,35)] int items1Size = 0;
    [SerializeField][Range(0, 35)] int items2Size =0;
    [SerializeField][Range(0, 35)] int items3Size = 0;
    [SerializeField][Range(0, 35)] int items4Size = 0;
    [SerializeField] Transform waponPoint;
    ItemsList.Item_count weapon;
    ItemsList.Item_count armo;
    GameObject m_weapon;
    int weaponLine;
    int armoLine;
    
    List<ItemsList.Item_count> items1 = new List<ItemsList.Item_count>(); //장비템창
    List<ItemsList.Item_count> items2 = new List<ItemsList.Item_count>(); //소비템창
    List<ItemsList.Item_count> items3 = new List<ItemsList.Item_count>(); //잡템창
    List<ItemsList.Item_count> items4 = new List<ItemsList.Item_count>(); //퀘스트템창
    
    private void Start()
    {
        if (items1Size >35)
            items1Size = 35;
        if (items2Size > 35)
            items2Size = 35;
        if (items3Size > 35)
            items3Size = 35;
        if (items4Size > 35)
            items4Size = 35;

        LoadItems();
    }
    public void SetPlayerInfo(int HP, int MP, int Damage, int Arm)
    {
        maxHp = HP;
        maxMp = MP;
        hp = HP;
        mp = MP;
        damage = Damage;
        arm = Arm;
    }
    public void SetWeapon(ItemsList.Item_count weapon, int line)
    {
        //1001
        bool codeNotChange = false;
        if (this.weapon !=null)
        {
            if (this.weapon.itemcode == weapon.itemcode)
            {
                codeNotChange = true;
            }
        }
        this.weapon = weapon;
        weaponLine = line;
        if (!codeNotChange)
        {
            if (m_weapon != null)
                Destroy(m_weapon);
            m_weapon = GameObject.Instantiate(Resources.Load<GameObject>("Prefab/Weapons/" + weapon.itemcode.ToString()), waponPoint);
        }
        
        itemDamage = InGameSystem.mainItemList.FindItem(weapon.itemcode).attack;
    }
    public void SetArmo(ItemsList.Item_count armo, int line)
    {
        this.armo = armo;
        armoLine = line;
        itemArm = InGameSystem.mainItemList.FindItem(armo.itemcode).deffend;
    }
    public void SetEqi() //장비 적용
    {
        if (waponPoint == null)
        {

        }
    }

    public int ALLDamage()
    {
        return damage + itemDamage;
    }
    public int ALLArm()
    {
        return arm + itemArm;
    }

    public void PlayerDamage(int damage)
    {
        hp -= damage;
    }
    public void LoadItems()
    {
        for (int a = 0; a<items1Size;a++)
        {
            items1.Add(new ItemsList.Item_count(0,0));
        }
        for (int a = 0; a < items2Size; a++)
        {
            items2.Add(new ItemsList.Item_count(0, 0));
        }
        for (int a = 0; a < items3Size; a++)
        {
            items3.Add(new ItemsList.Item_count(0, 0));
        }
        for (int a = 0; a < items4Size; a++)
        {
            items4.Add(new ItemsList.Item_count(0, 0));
        }
        gold = 0;
    }


    public int GetItemsSize(int n)
    {
        switch (n)
        {
            case 1:
                return items1Size;
            case 2:
                return items2Size;
            case 3:
                return items3Size;
            case 4:
                return items4Size;
        }
        return 0;
    }
    public List<ItemsList.Item_count> GetItemList(int n)
    {
        switch (n)
        {
            case 1:
                return items1;
            case 2:
                return items2;
            case 3:
                return items3;
            case 4:
                return items4;
        }
        return null;
    }
    int NoItemsCount(int itemnumber, int itemcode,out int line)
    {
        Debug.Log("Itemnumber = " + itemnumber);
        line = -1;
        int count = 0;
        List<ItemsList.Item_count> items = null;
        switch (itemnumber)
        {
            case 1:
                items = items1;
                break;
            case 2:
                items = items2;
                break;
            case 3:
                items = items3;
                break;
            case 4:
                items = items4;
                break;

        }
        if (items == null)
        {
            Debug.Log("ItemsNULL");
            return 0;
        }
        for (int a = 0; a < items.Count; a++)
        {
            if (itemnumber !=1)
            {
                if (items[a].itemcode == itemcode && items[a].itemCount <99) // 동일 아이템이 있고 갯수가 99개 밑일 경우
                {
                    count++;
                    line = a;
                    return count;
                }
            }

            if (items[a].itemcode == 0)
            {
                count++;
                if (line == -1)
                {
                    line = a;
                }
            }
        }
        return count;
    }
    public bool AddItems(int itemcode)
    {
        Debug.Log("AddItems Start");
        int number = itemcode/1000 == 1 ?2 : itemcode/1000;
        int line;
        if (NoItemsCount(number - 1,itemcode,out line) != 0)
        {
            Debug.Log(line);
           
            switch (number-1)
            {
                case 1:
                    items1[line].SetItemCode(itemcode);
                    items1[line].Items_coutPluse(1);
                    break;
                case 2:
                    items2[line].SetItemCode(itemcode);
                    items2[line].Items_coutPluse(1);
                    break;
                case 3:
                    items3[line].SetItemCode(itemcode);
                    items3[line].Items_coutPluse(1);
                    break;
                case 4:
                    items4[line].SetItemCode(itemcode);
                    items4[line].Items_coutPluse(1);
                    break;
            }

            Debug.Log("AddItems End True");
            return true;
        }
        Debug.Log("AddItems End False");
        InGameSystem.mainSubMenu.InventoryFull();
        return false;
    }
    public bool AddItems(int itemcode, int count)
    {
        Debug.Log("AddItems Start");
        int number = itemcode / 1000 == 1 ? 2 : itemcode / 1000;
        int line;
        List<ItemsList.Item_count> item = null;
        while (true)
        {
            if (NoItemsCount(number - 1, itemcode, out line) != 0)
            {
               
                Debug.Log(line);
                if (number - 1 == 2)
                    item = items2;
                else if (number - 1 == 3)
                    item = items3;
                else if (number - 1 == 4)
                    item = items4;

                if (item != null)
                {
                    item[line].SetItemCode(itemcode);
                    if (items2[line].itemCount + count > 99)
                    {
                        count = items2[line].itemCount + count - 99;
                    }
                    else
                    {
                        items2[line].Items_coutPluse(count);
                        Debug.Log("AddItems End True");
                        return true;
                    }
                }
            }
            Debug.Log("AddItems End False");
            InGameSystem.mainSubMenu.InventoryFull();
            return false;
        }
    }

    public ItemsList.Item_count EquiWeapon()
    {
        return weapon;
    }

    public ItemsList.Item_count EquiArmo()
    {
        return armo;
    }
    public bool CheckEqui(ItemsList.Item_count item)
    {
        if (weapon != null)
        {
            if (weapon == item)
                return true;
        }
        if (armo != null)
        {
            if (armo == item)
                return true;
        }
        Debug.Log("CheckFalse");
        return false;
    }
    public void PlusGold(int plusgold)
    {
        gold += plusgold;
    }
}
