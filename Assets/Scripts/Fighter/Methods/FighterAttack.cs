using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class FighterAttack : MonoBehaviour
{
    public ObjectAttributes objectAttributes;
    public FighterAttributes fighterAttributes;

    [SerializeField] private bool canAttack;
    private LinkedList<GameObject> enemies = new LinkedList<GameObject>();
    void Start()
    {
        objectAttributes = GetComponent<ObjectAttributes>();
        fighterAttributes = GetComponent<FighterAttributes>();
    }
    void Update()
    {
        StartCoroutine(Attack());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(objectAttributes.EnemyTag))
        {
            canAttack = true;
            if (enemies.Find(collision.gameObject) == null)
            {
                enemies.AddLast(collision.gameObject);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(objectAttributes.EnemyTag))
        {
            canAttack = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(objectAttributes.EnemyTag))
        {
            enemies.Remove(collision.gameObject);
            if (enemies.Count == 0)
            {
                canAttack = false;
            }
        }
    }

    bool isAttacking = false;
    IEnumerator Attack()
    {   
        if (!isAttacking && canAttack)
        {
            isAttacking = true;
            objectAttributes.IsAttacking = isAttacking;

            LinkedListNode<GameObject> currentEnemyNode = enemies.First;
            while (currentEnemyNode != null)
            {
                //Debug.Log(gameObject.name + " -> " + currentEnemyNode.Value.name);
                if (currentEnemyNode != null)
                {
                    currentEnemyNode.Value.GetComponent<ObjectReceiveHit>().ReceiveHit(objectAttributes.Damage);
                    currentEnemyNode = currentEnemyNode.Next;
                }
            }

            //Debug.Log(gameObject.name + " " + enemies.Count);

            yield return new WaitForSeconds(1f / objectAttributes.AttackSpeed);

            isAttacking = false;
            objectAttributes.IsAttacking = isAttacking;
        }
    }
}
