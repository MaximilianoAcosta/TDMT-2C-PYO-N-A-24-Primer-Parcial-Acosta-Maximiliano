using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private bool _HasEntityOn;

    private void OnEnable()
    {
        _HasEntityOn = false;
    }
    
    public void setIfHasEntityOn(bool check)
    {
        _HasEntityOn = check;
    }

   public bool CheckIfHasEntityOn()
    {
        return _HasEntityOn;
    }
}
