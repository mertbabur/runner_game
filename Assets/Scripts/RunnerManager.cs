using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerManager : MonoBehaviour
{

    private bool _isFinishHealt; // can bitti mi?
    private RunnerHealth _runnerHealtObject;
    private Enemy _enemyObject;
    private RetryPanelManager _retryPanelManager;
    [SerializeField] private GameObject retyPanel;



    private void Awake()
    {
        _runnerHealtObject = GameObject.FindObjectOfType<RunnerHealth>();
        _enemyObject = GameObject.FindObjectOfType<Enemy>();
        _retryPanelManager = GameObject.FindObjectOfType<RetryPanelManager>();
    }


    // Update is called once per frame
    void Update()
    {
    
        _isFinishHealt = _runnerHealtObject.IsFinishHealth(); // karakter canı bitti mi?

        if (_isFinishHealt) // can bitti mi ona göre oyun bitirilir
        {
            GameObject.FindObjectOfType<RunnerController>().SetStopGame();
            _retryPanelManager.OpenRetryPanel(retyPanel);
            //StartCoroutine(_runnerHealtObject.WaitCodeForDeadRunner());
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !_isFinishHealt) // düşman objesine çarparsak
        {
            _runnerHealtObject.DecreaseHealt();
            _enemyObject.DestroyEnemy();
        }
        if (other.gameObject.tag == "Fall")
        {
            gameObject.GetComponent<RunnerController>().enabled = false;
            _runnerHealtObject.SetZeroHealt();
            //StartCoroutine(WaitCodeForSetZeroHealth());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            //StartCoroutine(WaitCodeForSetZeroHealth());
            _runnerHealtObject.SetZeroHealt();
            
        }
       
    }
    
    /**
     * Canı sıfırlama metodu 1 saniye sonra çalışır
     */
    public IEnumerator WaitCodeForSetZeroHealth()
    {
        yield return new WaitForSeconds(1f);
        _runnerHealtObject.SetZeroHealt();
    }

    
}
