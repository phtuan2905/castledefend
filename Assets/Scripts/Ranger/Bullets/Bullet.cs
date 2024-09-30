using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Vector2 direction;
    void Awake()
    {
        
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

    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
