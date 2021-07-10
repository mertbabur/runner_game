using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    [SerializeField] private Text infoText;
    
    /**
     * Nerede kaldık ise oyunu oradan başlatır
     * SaveSytem aracılığı ile kayıtlı levelı getirir
     */
    public void StartGame()
    {
        PlayerData playerData = SaveSystem.LoadPlayer();
        int level = playerData.level;
        SceneManager.LoadScene(level);
    }

    /**
     * Oyundaki ilerlemeyi sıfırlar
     */
    public void ResetGame()
    {
        SaveSystem.SavePlayer(1,0);
        infoText.text = "YOUR GAME IS RESET";

    }
}
