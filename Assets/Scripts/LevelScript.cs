using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Script", menuName = "Level Script")]
public class LevelScript : ScriptableObject
{
    public List<TestClass1> monstersList;
}
