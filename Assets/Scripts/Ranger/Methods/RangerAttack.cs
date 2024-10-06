using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerAttack : MonoBehaviour
{
    public ObjectAttributes objectAttributes;
    public RangerAttributes rangerAttributes;
    public RangerDetectNearestEnemy rangerDetectNearestEnemy;

    [SerializeField] private GameObject nearestEnemy;
    [SerializeField] private Vector2 bulletDirection;

    void Start()
    {
        objectAttributes = GetComponent<ObjectAttributes>();
        rangerAttributes = GetComponent<RangerAttributes>();
        rangerDetectNearestEnemy = transform.Find("Detect Zone").GetComponent<RangerDetectNearestEnemy>();
    }

    void Update()
    {
        StartCoroutine(Attack());
    }

    bool isAttacking;
    IEnumerator Attack()
    {
        nearestEnemy = rangerDetectNearestEnemy.FindNearestEnemy();
        if (nearestEnemy != null && !isAttacking)
        {
            isAttacking = true;

            bulletDirection = nearestEnemy.transform.position - transform.position;
            CircleCollider2D range = transform.Find("Detect Zone").GetComponent<CircleCollider2D>();
            SpawnBullet(rangerAttributes.Bullet, objectAttributes.Damage, rangerAttributes.BulletSpeed, bulletDirection, range, objectAttributes.EnemyTag);
            Debug.DrawRay(transform.position, bulletDirection, Color.red, 1f);

            yield return new WaitForSeconds(1f / objectAttributes.AttackSpeed);
            
            isAttacking = false;
        }
    }

    void SpawnBullet(GameObject Bullet, float damage, float bulletSpeed, Vector2 direction, CircleCollider2D range, string enemyTag)
    {
        GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.FromToRotation(Vector3.up, transform.InverseTransformDirection(direction)));
        bullet.GetComponent<Bullet>().SetAttributes(damage, bulletSpeed, direction, range, enemyTag);
        //Debug.Log("Spawn bullet");
    }
}
