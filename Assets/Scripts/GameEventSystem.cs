using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEventSystem : MonoBehaviour
{
    public Canvas GUI;
    public GameObject losePanel;
    
    public void Lose()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
