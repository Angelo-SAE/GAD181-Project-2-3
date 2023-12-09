using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
  [SerializeField] private GameObject player, cameraCamera;

    void Awake()
    {
      GenerateMap();
    }

    public void GenerateMap()
    {
      player.transform.position = new Vector2(0.5f,0.5f);
      cameraCamera.transform.position = new Vector3(0.5f,0.5f, -10f);
      GenerateTilemap();
    }

      private void GenerateTilemap()
      {
        HashSet<Vector2Int> floorPositions = GetComponent<FloorGeneration>().GenerateFloor();
        GetComponent<TileMapPainter>().PaintFloorTiles(floorPositions);
        HashSet<Vector2Int> wallPositions = GetComponent<WallGeneration>().GenerateWall(floorPositions);
        GetComponent<TileMapPainter>().PaintWallTiles(GetComponent<WallGeneration>().GenerateWallType(floorPositions,wallPositions));
        Vector2Int holePosition = GetComponent<HoleGeneration>().GenerateHole(floorPositions, wallPositions);
        GetComponent<ExitLadder>().holeOverlap = holePosition;
        GetComponent<TileMapPainter>().PaintHoleTile(holePosition);
        HashSet<Vector2Int> objectPositions = new HashSet<Vector2Int>();
        objectPositions.Add(holePosition);
        Vector2Int chestPosition = GetComponent<ChestGeneration>().GenerateChest(floorPositions, wallPositions, objectPositions);
        GetComponent<OpenChestMenu>().chestOverlap = chestPosition;
        GetComponent<TileMapPainter>().PaintChestTile(chestPosition);
        objectPositions.Add(chestPosition);
        HashSet<Vector2Int> spikePositions = GetComponent<SpikeGeneration>().GenerateSpike(floorPositions, wallPositions, objectPositions);
        GetComponent<TileMapPainter>().PaintSpikeTiles(spikePositions);
        objectPositions = AddToHashSet(objectPositions, spikePositions);
        HashSet<Vector2Int> crossbowPositions = GetComponent<CrossBowTrapGeneration>().GenerateCrossbow(floorPositions, wallPositions, objectPositions);
        objectPositions = AddToHashSet(objectPositions, crossbowPositions);
        GetComponent<EnemyGeneration>().GenerateEnemy(floorPositions, objectPositions);
        GetComponent<ExitLadder>().holeClosed = true;
      }

      private HashSet<Vector2Int> AddToHashSet(HashSet<Vector2Int> first, HashSet<Vector2Int> second)
      {
        foreach(Vector2Int vInt in second)
        {
          first.Add(vInt);
        }
        return first;
      }

}
