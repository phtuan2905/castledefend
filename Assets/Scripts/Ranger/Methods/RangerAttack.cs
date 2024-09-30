using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerAttack : MonoBehaviour
{
    public RangerAttributes rangerAttributes;
    [SerializeField] private GameObject nearestEnemy;
    [SerializeField] private bool isAttacking;

    public GameObject NearestEnemy { set { nearestEnemy = value; } }
    void Start()
    {
        rangerAttributes = GetComponent<RangerAttributes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
        }
    }
}
