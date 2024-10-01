using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class FighterAttack : MonoBehaviour
{
    public FighterAttributes fighterAttributes;

    [SerializeField] private bool canAttack;
    [SerializeField] private List<GameObject> enemies;
    void Start()
    {
        fighterAttributes = GetComponent<FighterAttributes>();
    }
    void Update()
    {
        StartCoroutine(Attack());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(fighterAttributes.EnemyTag))
        {
            canAttack = true;
            enemies.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(fighterAttributes.EnemyTag))
        {
            canAttack = false;
            enemies.Remove(collision.gameObject);
        }
    }

    private bool isAttacking = false;
    IEnumerator Attack()
    {   
        if (!isAttacking && canAttack)
        {
            isAttacking = true;

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GetComponent<ObjectReceiveHit>().ReceiveHit(fighterAttributes.Damage);
            }

            yield return new WaitForSeconds(fighterAttributes.AttackSpeed);
            isAttacking = false;
        }
    }
}
