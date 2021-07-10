using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuePanelManager : MonoBehaviour
{
    [SerializeField] private GameObject _continuePanel;
    private LevelManager _levelManagerObject;
    private RunnerController _runnerControllerObject;

    private void Awake()
    {
        _levelManagerObject = GameObject.FindObjectOfType<LevelManager>();
        _runnerControllerObject = GameObject.FindObjectOfType<RunnerController>();
    }

    /**
     * Continue paneli açar
     */
    public void OpenContinuePanel()
    {
        _continuePanel.SetActive(true);
        StartCoroutine(WaitCodeForStopRunner());
    }

    /**
     * Oyunu bir sonraki leveldan devam ettirir
     */
    public void ContinueGame()
    {
        if (_levelManagerObject.GetActiveSceneIndex() == 3)
        {
            _levelManagerObject.GotoMenuScene();
        }
        else
        {
            _levelManagerObject.NextLevel();
        }
        
    }
    
    /**
     * Runner durdurma metodu 1 saniye sonra çalışır
     */
    public IEnumerator WaitCodeForStopRunner()
    {
        yield return new WaitForSeconds(0.2f); // 0.2 saniye sonra runner durmaya başlar
        StopRunner();
    }

    /**
     * Finish çizgisini geçince runnerı durdurur
     */
    private void StopRunner()
    {
        _runnerControllerObject.SetStopGame();
    }

}
