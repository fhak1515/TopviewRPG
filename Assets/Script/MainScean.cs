using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScean : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
        }
    }
}
