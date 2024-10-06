using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class RangerAttributes : MonoBehaviour
{
    public ScriptableObject rangerSO;
    
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float range;

    public GameObject Bullet { get => bullet; }
    public float BulletSpeed { get => bulletSpeed; }
    public float Range { get => range; }
}
