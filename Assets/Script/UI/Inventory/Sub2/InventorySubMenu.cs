using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySubMenu : MonoBehaviour
{
    [SerializeField] SubButtonAction[] m_buttons;
    [SerializeField] InventoryItems m_breachItems;
    RectTransform m_recttransform;
    public int m_index { private set; get; }

    void Awake()
    {
        m_recttransform = GetComponent<RectTransform>();
    }
    public void ShowSubMenu(Vector3 positon , int index)
    {
        gameObject.SetActive(true);
        m_index = index;
        positon.x += (m_recttransform.sizeDelta.x * transform.lossyScale.x)/2f;
        positon.y -= (m_recttransform.sizeDelta.y * transform.lossyScale.y)/2f;
        transform.position = positon;
    }
    public void HideSubMenu()
    {
        gameObject.SetActive(false);
    }
    public bool isActive()
    {
        return gameObject.activeInHierarchy;
    }
    public bool CheckPointIn(Vector3 point)
    {
        if (gameObject.activeInHierarchy)
        {
            Vector3 mouse = point;
            mouse -= m_recttransform.position;

            if (-(m_recttransform.sizeDelta.x * m_recttransform.lossyScale.x) / 2 <= mouse.x && (m_recttransform.sizeDelta.x * m_recttransform.lossyScale.x)/2 >= mouse.x
                && (m_recttransform.sizeDelta.y * m_recttransform.lossyScale.y/2) >= mouse.y && -(m_recttransform.sizeDelta.y * m_recttransform.lossyScale.y/2) <= mouse.y)
            {
                return true;
            }
            return false;
        }
        return false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = Input.mousePosition;
            if (CheckPointIn(point))
            {
                for (int a =0; a< m_buttons.Length; a++)
                {
                    if (m_buttons[a].CheckPointIn(point))
                    {
                        string buttonTag = m_buttons[a].gameObject.tag;
                        if (buttonTag == "Enqui")
                        {
                            Debug.Log("Enqui");
                            m_breachItems.Equip();
                        }
                        else if (buttonTag == "Use")
                        {
                            Debug.Log("Use");
                            m_breachItems.Use();
                        }
                        else if (buttonTag == "Sell")
                        {
                            Debug.Log("Sell");
                            m_breachItems.Sell();
                        }
                        else if(buttonTag == "Out")
                        {
                            Debug.Log("Out");
                            m_breachItems.Out();
                        }
                        HideSubMenu();
                        break;
                    }
                    
                }
            }
        }
    }
}
