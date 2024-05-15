using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] GridManager GridManager;
    [SerializeField] private Tile tile;
    [SerializeField] private List<GameObject> Characters;
    private void Start()
    {
        foreach (var character in Characters)
        {
            if (GridManager != null)
            {
                PlaceCharacterOnRandomTile(character);
            }

        }
    }
    private void PlaceCharacterOnRandomTile(GameObject character)
    {
        Vector2 tilePosition = GridManager.GetRandomGridPosition();
        tile = GridManager.GetTileAtPosition(tilePosition);
        if (!tile.CheckIfHasEntityOn())
        {
            Vector2 pos = tile.transform.position;
            character.transform.position = pos;
            if (character.TryGetComponent(out EntityMovement movement))
            {
                movement.SetPositionOnGrid(tilePosition);
            }
            tile.setIfHasEntityOn(true);
        }
        else 
        {
            PlaceCharacterOnRandomTile(character);     
        }
    }
}
