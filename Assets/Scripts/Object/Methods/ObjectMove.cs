using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public ObjectAttributes objectAttributes;
    public Rigidbody2D rg2D;
    public CircleCollider2D circleCollider2D;

    [SerializeField] private bool canMove;
    void Start()
    {
        objectAttributes = GetComponent<ObjectAttributes>();
        rg2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (objectAttributes.IsAttacking || circleCollider2D.IsTouchingLayers(LayerMask.GetMask("Object"))) return;
        transform.Translate(objectAttributes.MoveDirection * objectAttributes.MoveSpeed * Time.deltaTime);
    }
}
