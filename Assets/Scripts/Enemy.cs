using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private RunnerHealth _runnerHealtObject;

    private void Awake()
    {
        _runnerHealtObject = GameObject.FindObjectOfType<RunnerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Runner")
        {
            _runnerHealtObject.DecreaseHealt();
            DestroyEnemy();
        }
    }
    
    public void DestroyEnemy()
         {
             Destroy(gameObject);
         }
}
