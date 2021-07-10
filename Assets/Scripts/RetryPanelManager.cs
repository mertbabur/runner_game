using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryPanelManager : MonoBehaviour
{

    private LevelManager _levelManagerObject;

    private void Awake()
    {
        _levelManagerObject = GameObject.FindObjectOfType<LevelManager>();
    }

    /**
     * retyPaneli açar
     */
    public void OpenRetryPanel(GameObject retryPanel)
    {
        retryPanel.SetActive(true);
    }

    /**
     * retyPanel kapatır ve sahneyi tekrar yükler
     */
    public void RetryGame(GameObject retryPanel)
    {
        retryPanel.SetActive(false);
        _levelManagerObject.RestartScene();
        
    }
  
}
