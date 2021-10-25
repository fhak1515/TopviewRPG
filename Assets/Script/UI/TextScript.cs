using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    [SerializeField] Text textObject;
    Transform m_prent;
    Vector3 m_potition;
    float time;
    public void Update()
    {
        if (InGameSystem.inGamePause == true)
            return;
        if (time > 0)
        {
            transform.position += new Vector3(0,5*Time.deltaTime,0);
            time -= Time.deltaTime;
        }
        else
        {
            ResetText();
        }
    }
    public void SetText(Transform trnafrom)
    {
        m_prent = transform;
        m_potition = transform.position;
    }
    public void ShowText(string text,Vector3 position ,float time = 1f)
    {
        transform.position = m_potition + position;
        this.textObject.text = text;
        gameObject.SetActive(true);
    }
    private void ResetText()
    {
        transform.parent = m_prent;
        transform.position = m_potition;
        gameObject.SetActive(false);
    }
}
