using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _Width, _Height;
    [SerializeField] private Tile _tile;
    [SerializeField] private int GridDistance;
    private Dictionary<Vector2, Tile> _tilesPositions;
    private void Awake()
    {
        GenerateGrid();
    }
    void GenerateGrid()
    {
        _tilesPositions = new Dictionary<Vector2, Tile>();
        for (int i = 0; i < _Width; i++)
        {
            for (int j = 0; j < _Height; j++)
            {
                Vector2 SpawnPos = new Vector2(gameObject.transform.position.x + i * GridDistance, gameObject.transform.position.y + j * GridDistance);
                var spawnedTile = Instantiate(_tile, SpawnPos, Quaternion.identity);
                spawnedTile.name = $"Tile{i}{j}";
                _tilesPositions[new Vector2(i, j)] = spawnedTile;
            }
        }
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {

        if (_tilesPositions.TryGetValue(pos, out var tile))
        {

            return tile;
        }

        return null;
    }
    public Vector2 GetRandomGridPosition()
    {

        Vector2 RandomPos = new Vector2(Random.Range(0, _Width), Random.Range(0, _Height));
        return RandomPos;
    }
    
}
