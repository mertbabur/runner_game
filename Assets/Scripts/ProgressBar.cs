using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * FinishLine objesi içindeki finishDetect objesine yerleştir.
 */
public class ProgressBar : MonoBehaviour
{
    
    [SerializeField]
    private Transform playerObject;
    [SerializeField]
    private Transform endLine;
    [SerializeField]
    private Image progressBar;
    [SerializeField]
    private Text text1;
    [SerializeField]
    private Text text2;
    
    private float _maxDistance;
    public int activeSceneIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        _maxDistance = GetDistance();
        activeSceneIndex = GetActiveSceneIndex();
        SetLevelTexts();
    }

    // Update is called once per frame
    void Update()
    {
        // getDistance() / maxDistance --> uzakligi 1 arasina sikistirir.
        if (playerObject.position.z <= _maxDistance && playerObject.position.z <= endLine.position.z)
        {
            float distance = 1 - (GetDistance() / _maxDistance);
            SetProgressBar(distance);
        }
    }
    
    /**
     * Player ile bitis cizgisi arasindaki uzakligi hesaplar.
     */
    private float GetDistance()
    {
        return Vector3.Distance(playerObject.position, endLine.position);
    }

    /**
     * ProgressBar'i gunceller.
     */
    private void SetProgressBar(float distance)
    {
        progressBar.fillAmount = distance;
    }

    /**
     * ProgressBar'daki level'i belirten text'leri gunceller.
     */
    private void SetLevelTexts()
    {
        text1.text = (activeSceneIndex).ToString();
        text2.text = (activeSceneIndex + 1).ToString();
    }

    /**
     * O an ki oynanan scene'nin index'ini dondurur.
     */
    private int GetActiveSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
