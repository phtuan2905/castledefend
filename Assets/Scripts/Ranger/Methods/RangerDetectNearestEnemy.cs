using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerDetectNearestEnemy : MonoBehaviour
{
    private RangerAttributes rangerAttributes;
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private GameObject nearestEnemy;
    [SerializeField] [Range(0, 20)] private int maxEnemiesNumber;
    [SerializeField] private string enemyTag;

    void Start()
    {
        rangerAttributes = transform.parent.GetComponent<RangerAttributes>();
        GetComponent<CircleCollider2D>().radius = rangerAttributes.Range;
    }

    void Update()
    {
        FindNearestEnemy();
    }

    //enemies manage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag) && enemies.Count < maxEnemiesNumber)
        {
            enemies.Add(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag) && enemies.Count < maxEnemiesNumber)
        {
            enemies.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            enemies.Remove(collision.gameObject);
        }
    }

    //find nearest enemy
    private Vector2 nearestEnemyPosition;
    private float nearestEnemyDistance;
    void FindNearestEnemy()
    {
        if (enemies.Count != 0)
        {
            nearestEnemyPosition = enemies[0].transform.position;
            nearestEnemyDistance = Vector2.Distance(transform.position, nearestEnemyPosition);
            foreach (GameObject enemy in enemies)
            {
                if (Vector2.Distance(transform.position, enemy.transform.position) < nearestEnemyDistance)
                {
                    nearestEnemy = enemy;
                    nearestEnemyPosition = nearestEnemy.transform.position;
                    nearestEnemyDistance = Vector2.Distance(transform.position, nearestEnemy.transform.position);
                }
            }
        }
    }
}
