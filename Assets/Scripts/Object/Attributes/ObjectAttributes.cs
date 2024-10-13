using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAttributes : MonoBehaviour
{
    public ScriptableObject objectSO;

    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private string enemyTag;
    [SerializeField] private List<string> selfTags;
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private int energy;

    [SerializeField] private float healthPercent = 1;
    [SerializeField] private float damagePercent = 1;
    [SerializeField] private float attackSpeedPercent = 1;
    [SerializeField] private float moveSpeedPercent = 1;

    [SerializeField] private bool isAttacking;

    public float Health { get => health * healthPercent; set => health = value; }
    public float Damage { get => damage * damagePercent; }
    public float AttackSpeed { get => attackSpeed * attackSpeedPercent; }
    public float MoveSpeed { get => moveSpeed * moveSpeedPercent; }
    public string EnemyTag { get => enemyTag; }
    public List<string> SelfTags { get => selfTags; }
    public Vector2 MoveDirection { get => moveDirection; set => moveDirection = value; }
    public int Energy { get => energy; set => energy = value; }

    public float HealthPercent { set => healthPercent = value; }
    public float DamagePercent { set => damagePercent = value; }
    public float AttackSpeedPercent { set => attackSpeedPercent = value; }
    public float MoveSpeedPercent { set => moveSpeedPercent = value; }

    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }

    private void Awake()
    {
        if (transform.parent != null && transform.parent.GetComponent<ObjectAttributes>() == null) transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);

    }
}
