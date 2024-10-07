using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public ObjectAttributes objectAttributes;
    public Rigidbody2D rg2D;

    void Start()
    {
        objectAttributes = GetComponent<ObjectAttributes>();
        rg2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (!objectAttributes.IsAttacking)
        {
            rg2D.velocity = objectAttributes.MoveDirection.normalized * objectAttributes.MoveSpeed;
        }
        else
        {
            rg2D.velocity = Vector2.zero;
        }

    }
}
