using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    GameObject entity;
    [SerializeField] EntityMovement _movement;
    static int numberOfMoves;
    
    public void SetEntityToMove(GameObject entityToMove)
    {
        entity = entityToMove;
        _movement = entityToMove.GetComponent<EntityMovement>();
        numberOfMoves = entity.GetComponent<PlayerBehaviour>().GetSpeed();
    }
    public void OnMove(InputAction.CallbackContext context)
    {

        if (context.performed && numberOfMoves > 0)
        {
            _movement.TryMovement(context.ReadValue<Vector2>());
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
