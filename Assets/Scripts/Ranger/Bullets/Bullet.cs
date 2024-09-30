using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rg2D;

    [SerializeField] private float damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Vector2 direction;

    void Start()
    {
        rg2D = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        Move();
    }

    public void SetAttributes(float Damage, float BulletSpeed, Vector2 Direction)
    {
        damage = Damage;
        bulletSpeed = BulletSpeed;
        direction = Direction;
    }

    void Move()
    {
        rg2D.velocity = direction.normalized * bulletSpeed;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
