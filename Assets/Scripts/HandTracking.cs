using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking_old : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject[] handPoints;

    void Update()
    {
        string data = udpReceive.data;
    }
}