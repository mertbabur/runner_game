using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunnerHealth : MonoBehaviour
{
    
    [SerializeField] private int _runnerHealth = 100; // runner canı
    [SerializeField] private Text _healthText; // runner canını yazdırdığımız text

    /**
     * Canın bitip bitmediğini kontrol eder
     * Can 0 ise true, değilse false
     */
    public bool IsFinishHealth()
    {
        if (_runnerHealth != 0)
        {
            return false;
        }

        return true;
    }
    
    /**
     * Canı 20 azaltır
     */
    public void DecreaseHealt()
    {
        _runnerHealth -= 10;
        _healthText.text = _runnerHealth.ToString();
    }

    /**
     * Runner objesini yok eder
     */
    public void DeadRunner()
    {
        Destroy(gameObject);
    }

    /**
     * Canı 0'a eşitler
     */
    public void SetZeroHealt()
    {
        _runnerHealth = 0;
    }
    
    /**
     * DeadRunner metodunu 1 saniye bekletir
     */
    public IEnumerator WaitCodeForDeadRunner()
    {
        yield return new WaitForSeconds(1f);
        DeadRunner();
    }
    
}
