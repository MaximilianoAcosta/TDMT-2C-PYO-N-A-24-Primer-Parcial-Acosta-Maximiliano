using UnityEngine;


public class EntityMovement : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    private Vector2 _PositionOnGrid;
    public void SetPositionOnGrid(Vector2 pos)
    {
        _PositionOnGrid = pos;
    }
    public bool TryMovement(Vector2 direction)
    {
        Vector2 newPos = _PositionOnGrid + direction;
        Tile thisTile = gridManager.GetTileAtPosition(_PositionOnGrid);  
        Tile newTile;
        newTile = gridManager.GetTileAtPosition(newPos);
        if (newTile != null && !newTile.CheckIfHasEntityOn())
        {
      
            thisTile.setIfHasEntityOn(false);
            SetPositionOnGrid(newPos);
            transform.position = newTile.transform.position;
            newTile.setIfHasEntityOn(true);
            PlayerMovement.ReduceNumberOfMoves();
            return true;
        }
        return false;
    }
    public Vector2 GetPositionOnGrid()
    {
        return _PositionOnGrid;
    }
 
}
