using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private int level;
    public int Level { get => level; set => level = value; }

    [SerializeField] private LevelScript levelScript;
    public LevelScript LevelScript { get => levelScript; set => levelScript = value; }
}
