using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerDetectNearestEnemy : MonoBehaviour
{
    public ObjectAttributes objectAttributes;
    public RangerAttributes rangerAttributes;

    [SerializeField] private List<GameObject> enemnies;
    [SerializeField] private GameObject nearestEnemy;
    [SerializeField] [Range(0, 20)] private int maxEnemiesNumber;
    [SerializeField] private float range;
    void Start()
    {
        rangerAttributes = transform.parent.GetComponent<RangerAttributes>();
        range = rangerAttributes.Range;
        objectAttributes = transform.parent.GetComponent<ObjectAttributes>();
        GetComponent<CircleCollider2D>().radius = range;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(objectAttributes.EnemyTag) && !enemnies.Contains(collision.gameObject) && enemnies.Count < maxEnemiesNumber)
        {
            enemnies.Add(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(objectAttributes.EnemyTag) && !enemnies.Contains(collision.gameObject) && enemnies.Count < maxEnemiesNumber)
        {
            enemnies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(objectAttributes.EnemyTag) && enemnies.Contains(collision.gameObject))
        {
            enemnies.Remove(collision.gameObject);
        }
    }

    public GameObject FindNearestEnemy()
    {
        if (enemnies.Count == 0)
        {
            nearestEnemy = null;
            return nearestEnemy;
        }

        if (enemnies[0] == null) return nearestEnemy = null;
        nearestEnemy = enemnies[0];
        float distance = Vector2.Distance(transform.position, nearestEnemy.transform.position);
        foreach (GameObject enemy in enemnies)
        {
            if (enemy != null && Vector2.Distance(transform.position, enemy.transform.position) < distance)
            {
                nearestEnemy = enemy;
                distance = Vector2.Distance(transform.position, enemy.transform.position);
            }
        }
        return nearestEnemy;
    }
}
