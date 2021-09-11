using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scriptcode
{
    public static Quaternion GetRotFromVectors(Vector2 posStart, Vector2 posEnd)
    {
        return Quaternion.Euler(0, 0, -Mathf.Atan2(posEnd.x - posStart.x, posEnd.y - posStart.y) * Mathf.Rad2Deg);
    }
    public static Quaternion GetMouseFromVector(Vector3 TurnTarget)
    {
        Vector3 mousepoint = GetWoldMousePoint();

        return Quaternion.Euler(0, 0,-Mathf.Atan2(mousepoint.z - TurnTarget.z, mousepoint.x - TurnTarget.x) * Mathf.Rad2Deg);
        //return Quaternion.Euler(0, -Mathf.Atan2(TurnTarget.z - mousepoint.z, TurnTarget.x - mousepoint.x) * Mathf.Rad2Deg, 0);
    }
    public static Vector3 GetWoldMousePoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        return Vector3.zero;
    }

    
}


//Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
//return Quaternion.Euler(0,0,-Mathf.Atan2(posEnd.x - posStart.x, posEnd.y - posStart.y) * Mathf.Rad2Deg);
//GameObject.transform.rotation = GetRotFromVectors( GameObject.transfrom.position, GameObject.transform.position);