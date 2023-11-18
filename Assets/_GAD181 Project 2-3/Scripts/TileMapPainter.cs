using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapPainter : MonoBehaviour
{
  [SerializeField] private Tilemap floor, wall;
  [SerializeField] private TileBase floorTile, wallTile;
  private HashSet<Vector2Int> tilelocattest = new HashSet<Vector2Int>();

  void Start()
  {
    tilelocattest.Add(new Vector2Int(0,0));
    tilelocattest.Add(new Vector2Int(1,1));
    tilelocattest.Add(new Vector2Int(2,2));
    tilelocattest.Add(new Vector2Int(3,3));
    tilelocattest.Add(new Vector2Int(4,4));
    tilelocattest.Add(new Vector2Int(5,5));
    tilelocattest.Add(new Vector2Int(6,6));
  }

  void Update()
  {
    if(Input.GetKeyDown(KeyCode.J))
    {
      PaintFloorTiles(tilelocattest);
    }
  }

  public void PaintFloorTiles(HashSet<Vector2Int> tileLocations)
  {
    foreach(Vector2Int position in tileLocations)
    {
      TilePainter(floor, position, floorTile);
    }
  }

  private void TilePainter(Tilemap map, Vector2Int location, TileBase tile)
  {
    map.SetTile((Vector3Int)location, tile);
  }


}
