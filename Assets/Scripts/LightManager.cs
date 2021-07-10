using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Light>().color = Color.white; // oyun ilk başladığında sahne ışığı beyaz yapılır
    }
}
