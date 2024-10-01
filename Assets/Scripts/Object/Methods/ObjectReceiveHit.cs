using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReceiveHit : MonoBehaviour
{
    private ObjectAttributes objectAttributes;
    void Start()
    {
        objectAttributes = GetComponent<ObjectAttributes>();   
    }

    public void ReceiveHit(float damage)
    {
        objectAttributes.Health -= damage;
        if (objectAttributes.Health <= 0) Destroy(gameObject);
    }
}
