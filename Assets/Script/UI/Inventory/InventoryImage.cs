using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryImage : MonoBehaviour
{
    [SerializeField] InventorySub2 sub2;

    private void OnMouseEnter()
    {
        sub2.EnterCanvasPoint();
    }

    private void OnMouseExit()
    {
        sub2.ExitCanvasPoint();
    }
}
