using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerAttack : MonoBehaviour
{
    public RangerAttributes rangerAttributes;
    public RangerDetectNearestEnemy rangerDetectNearestEnemy;
    public RangerSpawnBullet rangerSpawnBullet;

    [SerializeField] private GameObject nearestEnemy;
    [SerializeField] private Vector2 bulletDirection;

    void Start()
    {
        rangerAttributes = GetComponent<RangerAttributes>();
        rangerDetectNearestEnemy = transform.Find("Detect Zone").GetComponent<RangerDetectNearestEnemy>();
        rangerSpawnBullet = GetComponent<RangerSpawnBullet>();
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
            rangerSpawnBullet.SpawnBullet(rangerAttributes.Bullet, rangerAttributes.BulletSpeed, rangerAttributes.Damage, bulletDirection);
            yield return new WaitForSeconds(rangerAttributes.AttackSpeed);
            isAttacking = false;
        }
    }
}
