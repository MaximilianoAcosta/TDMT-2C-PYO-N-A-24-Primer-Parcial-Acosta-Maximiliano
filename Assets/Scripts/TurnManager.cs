using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Characters;
    [SerializeField] PlayerMovement PlayerMovement;
    [SerializeField] int TurnCount;

    private void Start()
    {
        TurnCount = 0;
        characterInTurn(Characters[TurnCount]);
    }
    private void characterInTurn(GameObject character)
    {
        PlayerMovement.setEntityToMove(character);
    }

    public void OnChangeTurn(InputAction.CallbackContext context)
    {
        Debug.Log("TurnChanged");
        if (context.performed)
        {
            TurnCount++;
            if(TurnCount == Characters.Count) { TurnCount = 0; }
            characterInTurn(Characters[TurnCount]);
        }
    }
}
