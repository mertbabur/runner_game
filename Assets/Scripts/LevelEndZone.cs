using System;
using UnityEngine;
/**
 * FinishGamePlatform icindeki EndLine'dan sonra altta kalan cube'lere ve LevelEndZone' a eklenir.
 */
public class LevelEndZone : MonoBehaviour
{
    private int _level;
    public int coin;

    private ContinuePanelManager _continuePanelManagerObject;

    private void Awake()
    {
        _continuePanelManagerObject = GameObject.FindObjectOfType<ContinuePanelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Runner")
        {
            SetLevelSceneIndex();
            SetCoinQuantity();
            SaveSystem.SavePlayer(_level, coin);
            _continuePanelManagerObject.OpenContinuePanel();
            
        }
    }

    /**
     * Sonraki level'i hafizada tutamak icin activeSceneIndex uzerine 1 eklenir.
     */
    private void SetLevelSceneIndex()
    {
        _level = FindObjectOfType<ProgressBar>().activeSceneIndex + 1; // sonraki level'i hafizada tutmak icin.
    }

    /**
     * Level sonunda toplam _score coin' e atar.
     */
    private void SetCoinQuantity()
    {
        coin = FindObjectOfType<ScoreManager>()._score;
    }

}
