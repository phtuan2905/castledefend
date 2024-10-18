using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object SO", menuName = "Object SO")]
public class ObjectSO : ScriptableObject
{
    public float health;
    public float damage;
    public float attackSpeed;
    public float moveSpeed;
    public string enemyTag;
    public List<string> selfTags;
    public Vector2 moveDirection;
    public float energy;
}
