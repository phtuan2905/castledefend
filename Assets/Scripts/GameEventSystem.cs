using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameEventSystem : MonoBehaviour
{
    public void Win()
    {
        //SceneManager.LoadScene("SampleScene");
        Debug.Log("Win");
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public GameObject UI;

    public GameObject losePanel;
    
    public void Lose()
    {
        Debug.Log("Lose");
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public MonsterSpawnerManage monsterSpawnerManage;
    public GameObject monsterManager;
    public LevelSystem levelSystem;
    public void StartLevel(int levelNumber)
    {
        monsterSpawnerManage.LevelScript = levelSystem.LevelScript;
        monsterSpawnerManage.gameObject.SetActive(true);
        monsterManager.SetActive(true);
    }

    public void ChangeGameMenu(int menuIndex)
    {
        DeactiveAllMenu();
        UI.transform.GetChild(menuIndex).gameObject.SetActive(true);
    }

    void DeactiveAllMenu()
    {
        foreach (Transform menu in UI.transform)
        {
            menu.gameObject.SetActive(false);
        }
    }

    public Image healthBarFill;
    public TextMeshProUGUI healthText;
    public Image energyBarFill;
    public TextMeshProUGUI energyText;
    public void SetAttributeBar(int attributeType, float attributeNumberCurrent, float attributeNumberMax)
    {
        if (attributeType == 0)
        {
            healthBarFill.fillAmount = attributeNumberCurrent / attributeNumberMax;
            healthText.text = attributeNumberCurrent.ToString();
            healthText.text += "/";
            healthText.text += attributeNumberMax.ToString();
        }
        else
        {
            energyBarFill.fillAmount = attributeNumberCurrent / attributeNumberMax;
            energyText.text = attributeNumberCurrent.ToString();
            energyText.text += "/";
            energyText.text += attributeNumberMax.ToString();
        }
    }
}
