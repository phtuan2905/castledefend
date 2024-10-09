using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCastleDestroy : MonoBehaviour
{
    public GameEventSystem gameEventSystem;
    private void OnDestroy()
    {
        gameEventSystem.Lose();
    }
}
