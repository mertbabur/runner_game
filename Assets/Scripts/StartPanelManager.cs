using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    
    /**
     * Button bastığımızda oyunu başlatır
     */
    public void StartGame()
    {
        GameObject.FindObjectOfType<RunnerController>().SetStartGame();
        ClosePanel();
        Debug.Log("VAR");
    }
    
    /**
     * StartPaneli kapatır
     */
    private void ClosePanel()
    {
        startPanel.SetActive(false);
    }
    
}
