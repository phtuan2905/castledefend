using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAttributes : MonoBehaviour
{
    [SerializeField] private ScriptableObject objectSO;
    [SerializeField] private float health;

    public float Health { set { health = value; } get { return health; } }
}
