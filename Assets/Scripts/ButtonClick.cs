using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public GameObject slotsManager;

    public bool isHolding;

    public GameObject solider;
    
    public void PlaceSolider()
    {
        if (!slotsManager.activeInHierarchy)
        {
            slotsManager.SetActive(true);
            slotsManager.GetComponent<SlotsManage>().solider = solider;
            slotsManager.GetComponent<SlotsManage>().isHolding = isHolding;
        }
        else
        {
            slotsManager.GetComponent<SlotsManage>().solider = null;
            slotsManager.GetComponent<SlotsManage>().isHolding = false;
            slotsManager.SetActive(false);
            isHolding = false;
        }
    }

    public GameEventSystem gameEventSystem;
    public void StartCurrentLevel()
    {
        gameEventSystem.StartLevel(0);
        gameEventSystem.ChangeGameMenu(1);
    }
}
