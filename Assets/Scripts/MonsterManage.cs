using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManage : MonoBehaviour
{
    public GameEventSystem gameEventSystem;
    public bool canCheck;
    private void LateUpdate()
    {
        if (transform.childCount == 0 && canCheck) gameEventSystem.Win();
    }
}
