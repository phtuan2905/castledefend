using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public ObjectAttributes objectAttributes;
    public Rigidbody2D rg2D;

    [SerializeField] private bool canMove;
    void Start()
    {
        objectAttributes = GetComponent<ObjectAttributes>();
        rg2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(null))
        {
            canMove = false;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(null))
        {
            canMove = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(null))
        {
            canMove = true;
        }
    }

    void Move()
    {
        if (!objectAttributes.IsAttacking && canMove)
        {
            transform.Translate(objectAttributes.MoveDirection * objectAttributes.MoveSpeed * Time.deltaTime);
        }
    }
}
