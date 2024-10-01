using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    private void OnDestroy()
    {
        transform.position = new Vector3(100, 100, 0);
        Debug.Log(gameObject.name + " dead");
    }
}
    