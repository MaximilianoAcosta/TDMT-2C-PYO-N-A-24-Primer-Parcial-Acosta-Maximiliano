using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] EntityMovement _Movement;
    [SerializeField] List<AttackButton> _AttackButtons;
    [SerializeField] List<HealButton> _HealButton;
    [Space(10)]
    GameObject entity;
    static int numberOfMoves;
    const float startWaitTime = 0.005f;

    private void Start()
    {

        StartCoroutine(LateStart(startWaitTime));
    }
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ButtonDisplay();
    }
    public void SetEntityToMove(GameObject entityToMove)
    {
        entity = entityToMove;
        _Movement = entityToMove.GetComponent<EntityMovement>();
        numberOfMoves = entity.GetComponent<PlayerBehaviour>().GetSpeed();
    }
    public void OnMove(InputAction.CallbackContext context)
    {

        if (context.performed && numberOfMoves > 0)
        {
            _Movement.TryMovement(context.ReadValue<Vector2>());
            ButtonDisplay();
        }
    }

    public void OnMove(Vector2 vector2)
    {
        if (numberOfMoves > 0)
        {
            _Movement.TryMovement(vector2);
            ButtonDisplay();

        }
    }

    private void ButtonDisplay()
    {
        foreach (var button in _AttackButtons)
        {
            button.OnMove();
        }
        foreach (var button in _HealButton)
        {
            button.OnMove();
        }
    }

    public static void ReduceNumberOfMoves()
    {
        numberOfMoves--;
    }
    public static void BlockMovement()
    {
        numberOfMoves =0;   
    }
}
