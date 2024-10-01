using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rg2D;

    [SerializeField] private float damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Vector2 direction;
    [SerializeField] private Collider2D range;
    [SerializeField] private string enemyTag;

    void Start()
    {
        rg2D = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        Move();
    }

    public void SetAttributes(float Damage, float BulletSpeed, Vector2 Direction, CircleCollider2D Range, string EnemyTag)
    {
        damage = Damage;
        bulletSpeed = BulletSpeed;
        direction = Direction;
        range = Range;
        enemyTag = EnemyTag;
    }

    void Move()
    {
        rg2D.velocity = direction.normalized * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            collision.GetComponent<ObjectReceiveHit>().ReceiveHit(damage);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == range)
        {
            Destroy(gameObject);
        }
    }
}
