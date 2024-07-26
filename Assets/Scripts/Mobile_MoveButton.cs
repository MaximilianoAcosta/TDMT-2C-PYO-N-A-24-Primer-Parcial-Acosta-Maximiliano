using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mobile_MoveButton : MonoBehaviour
{
    [SerializeField] Vector2 _Direction;
    [SerializeField] PlayerMovement _PlayerMovement;
    Button _MoveButton;

    private void Start()
    {
        _MoveButton = GetComponent<Button>();
        _MoveButton.onClick.AddListener(delegate { _PlayerMovement.OnMove(_Direction); });
    }

}
