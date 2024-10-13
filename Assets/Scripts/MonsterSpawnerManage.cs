using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerManage : MonoBehaviour
{
    public GameEventSystem gameEventSystem;
    public GameObject monsterManager;

    [SerializeField] private LevelScript levelScript;
    [SerializeField] private float timePerSpawn;

    private int currentMonsterNumber;
    bool isSpawning;

    public LevelScript LevelScript { get => levelScript; set => levelScript = value; }

    void Update()
    {
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        if (!isSpawning && currentMonsterNumber < LevelScript.monstersList[0].number) 
        {
            currentMonsterNumber++;
            isSpawning = true;

            int randomSpawner = Random.Range(0, transform.childCount);
            GameObject clone = Instantiate(LevelScript.monstersList[0].monster, monsterManager.transform);
            clone.transform.position = transform.GetChild(randomSpawner).position;
            if (currentMonsterNumber == LevelScript.monstersList[0].number) monsterManager.GetComponent<MonsterManage>().canCheck = true; 
            
            yield return new WaitForSeconds(timePerSpawn);

            isSpawning = false;
        }

    }
}
