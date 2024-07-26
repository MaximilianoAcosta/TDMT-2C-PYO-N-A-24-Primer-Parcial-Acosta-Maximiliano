using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AndroidControllerManager : MonoBehaviour
{
    [SerializeField] GameObject controller;
    bool ActiveAndroid = false;
    
    


        private void Start()
    {
#if UNITY_ANDROID
    ActiveAndroid = true;
#endif
        
        if (ActiveAndroid)
        {
            controller.SetActive(true);
        }
    }

}
