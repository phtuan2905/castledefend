using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] private int monsterNumber;
    [SerializeField] private int monsterCurrentNumber = 0;
    [SerializeField] private GameObject monster;

    private void Awake()
    {
        GameObject monsterClone = Instantiate(monster);
        monsterClone.transform.position = transform.position;
        monsterCurrentNumber++;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster") && monsterCurrentNumber < monsterNumber)
        {
            GameObject monsterClone = Instantiate(monster);
            monsterClone.transform.position = transform.position;
            monsterCurrentNumber++;
        }
    }
}
