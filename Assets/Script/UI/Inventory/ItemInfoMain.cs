using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoMain : MonoBehaviour
{
    [SerializeField] ItemInfo[] m_iteminfos;
    RectTransform rectTransform;
    int number;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void ShowItemInfoMain(Items item)
    {
        if (item.GetItemCode() == 0)
            return;

        number = item.GetItemType();
        if (number >= m_iteminfos.Length)
            number = m_iteminfos.Length;
        number--;
        m_iteminfos[number].SetItem(item);

        PositionIsMouse();

        gameObject.SetActive(true);
    }
    private void Update()
    {
        PositionIsMouse();
    }
    void PositionIsMouse()
    {
        Vector3 point = Input.mousePosition;
        point.x += 10f;
        point.y -= 10f;
        transform.position = point;
    }
    public void HideItemInfoMain()
    {
        m_iteminfos[number].Hide();
        gameObject.SetActive(false);
    }
}
