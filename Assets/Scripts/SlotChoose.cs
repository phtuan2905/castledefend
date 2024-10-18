using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotChoose : MonoBehaviour
{
    public PolygonCollider2D polygonCollider2D;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        if (polygonCollider2D == null) { polygonCollider2D = GetComponent<PolygonCollider2D>(); spriteRenderer = GetComponent<SpriteRenderer>(); }
        if (!polygonCollider2D.IsTouchingLayers(LayerMask.GetMask("Object")))
        {
            spriteRenderer.color = Color.green;
            return;
        }
        spriteRenderer.color = Color.red;
    }

    private void OnMouseDown()
    {
        if (!polygonCollider2D.IsTouchingLayers(LayerMask.GetMask("Object")))
        {
            GameObject soliderClone = Instantiate(transform.parent.GetComponent<SlotsManage>().solider);
            soliderClone.transform.position = transform.position;
            if (!transform.parent.GetComponent<SlotsManage>().isHolding) { transform.parent.gameObject.SetActive(false); }
        }
    }
}
