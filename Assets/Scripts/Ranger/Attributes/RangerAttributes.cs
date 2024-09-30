using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class RangerAttributes : MonoBehaviour
{
    [SerializeField] private ScriptableObject rangerSO;
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float range;
    [SerializeField] private float numberOfAttacks;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private string enemyTag;

    [Header("Changable")]
    [SerializeField] private GameObject nearestEnemy;

    void Start()
    {

    }

    public float Damage { get { return damage; } }
    public float AttackSpeed { get { return attackSpeed; } }
    public float Range {  get { return range; } }
    public float NumberOfAttacks { get { return numberOfAttacks; } }
    public GameObject Bullet { get { return bullet; } }
    public float BulletSpeed { get { return bulletSpeed; } }
    public GameObject NearestEnemy { set { nearestEnemy = value; } get { return nearestEnemy; } }
}
