using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] public int _score = 0;
    public int _scoreForLevel; // o level'da kac coin toplandigini tutar.

    private void Start()
    {
        LoadCoinQuantity();
    }

    /**
     * Her elmas aldığımızda score amount kadar artar
     */
    public void AddScore(int amount)
    {
        _score += amount;
        _scoreForLevel += amount;
        _scoreText.text = _score.ToString("N0");
    }
    
    /**
     * Cihaz hafizasindaki coin sayisini getirir.
     */
    private void LoadCoinQuantity()
    {
        _score = SaveSystem.LoadPlayer().coin;
        _scoreText.text = _score.ToString();
    }

    
}
