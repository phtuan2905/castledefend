using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerAttack : MonoBehaviour
{
    public RangerAttributes rangerAttributes;
    public RangerDetectNearestEnemy rangerDetectNearestEnemy;

    [SerializeField] private GameObject nearestEnemy;
    [SerializeField] private Vector2 bulletDirection;

    void Start()
    {
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
            SpawnBullet(rangerAttributes.Bullet, rangerAttributes.BulletSpeed, rangerAttributes.Damage, bulletDirection);

            yield return new WaitForSeconds(rangerAttributes.AttackSpeed);
            
            isAttacking = false;
        }
    }

    void SpawnBullet(GameObject Bullet, float damage, float bulletSpeed, Vector2 direction)
    {
        GameObject bullet = Instantiate(Bullet, transform.position);
        bullet.GetComponent<Bullet>().SetAttributes(damage, bulletSpeed, direction);
        Debug.Log("Spawn bullet");
    }
}
