using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFpsOnStart : MonoBehaviour
{
    static int target = 60;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }

    void Update()
    {
        if (Application.targetFrameRate != target)
            Application.targetFrameRate = target;
    }
}
