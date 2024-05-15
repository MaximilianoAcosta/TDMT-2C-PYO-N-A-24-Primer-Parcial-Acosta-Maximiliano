using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    GameObject entity;
    [SerializeField] EntityMovement _movement;
    static int numberOfMoves;
    public void setEntityToMove(GameObject entityToMove)
    {
        entity = entityToMove;
        _movement = entityToMove.GetComponent<EntityMovement>();
        numberOfMoves = entity.GetComponent<PlayerBehaviour>().getSpeed();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed && numberOfMoves > 0)
        {
            Debug.Log(context.ReadValue<Vector2>());
            _movement.TryMovement(context.ReadValue<Vector2>());
        }

    }
    public static void reduceNumberOfMoves()
    {
        numberOfMoves--;
    }
}
