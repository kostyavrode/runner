using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeInncreaser : MonoBehaviour
{
    void Update()
    {
        Time.timeScale += 0.00005f;
    }
}
