using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTest1 : MonoBehaviour
{
    int i_update =0;
    int i_lateupdate =0;
    int i_fixedupdate = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }
    void FixedUpdate()
    {
        i_fixedupdate++;
        Debug.Log("FixedUpdate : " + i_fixedupdate);
    }
    // Update is called once per frame
    void Update()
    {
        i_update++;
        Debug.Log("Update : " + i_update);
    }
    private void LateUpdate()
    {
        i_lateupdate++;
        Debug.Log("LateUpdate : " + i_lateupdate);
    }
}
