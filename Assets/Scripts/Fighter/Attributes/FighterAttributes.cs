using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAttributes : MonoBehaviour
{
    public ScriptableObject fighterSO;
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private string enemyTag;

    public float Damage { get { return damage; } }
    public float AttackSpeed { get { return attackSpeed; } }
    public string EnemyTag { get {  return enemyTag; } }
}
