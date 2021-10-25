using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] Transform ActiveText;
    [SerializeField] Transform NotActiveText;
    Transform m_recoveryText;
    public enum TextType
    {
        Damage,
        Recovery
    }
    private void Start()
    {
        /*
        for ( int a = 0; a< 20; a++) //20개의 대미지 Text;
        {

        }
        */
    }

    public void ShowText(TextType type, string text, Vector3 textPosition, float time= 1f)
    {
        switch (type)
        {
            case TextType.Damage:
                DamageText(text, textPosition, time);
                break;
            case TextType.Recovery:
                DamageText(text, textPosition, time);
                break;
        }
    }

    private void DamageText(string textString, Vector3 textPostion, float time = 1f)
    {
        Transform textobject;
        if (NotActiveText.childCount>0)
        {
            textobject = NotActiveText.GetChild(0);
        }
        else
        {
            textobject = ActiveText.GetChild(0);
        }
        textobject.gameObject.SetActive(true);
        textobject.gameObject.GetComponent<TextScript>().ShowText(textString, textPostion,time);
        
    }

    private void RecoverText(string textString, Vector3 textPostion, float time= 1f)
    {
        m_recoveryText.gameObject.SetActive(true);
        m_recoveryText.gameObject.GetComponent<TextScript>().ShowText(textString, textPostion, time);
    }
}
