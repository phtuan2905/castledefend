using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotCheck : MonoBehaviour
{
    private PolygonCollider2D polygonCollider2D;

    private void Start()
    {
           polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    private void OnMouseDown()
    {
        if (!polygonCollider2D.IsTouchingLayers(LayerMask.GetMask("Object"))){
            GameObject soliderClone = Instantiate(transform.parent.GetComponent<SlotsManage>().solider);
            soliderClone.transform.position = transform.position;
            transform.parent.gameObject.SetActive(false);
        }
    }
}
