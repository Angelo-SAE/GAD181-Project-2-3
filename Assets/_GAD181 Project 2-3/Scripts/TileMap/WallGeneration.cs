using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGeneration : MonoBehaviour
{
    public HashSet<Vector2Int> GenerateWall(HashSet<Vector2Int> floorPositions)
    {
      HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
      foreach(Vector2Int position in floorPositions)
      {
        foreach(Vector2Int direction in StaticTilemaps.allDirections)
        {
          if(!floorPositions.Contains(position + direction))
          {
            wallPositions.Add(position + direction);
          }
        }
      }
      return wallPositions;
    }

    public HashSet<Vector3Int> GenerateWallType(HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> wallPositions)
    {
      HashSet<Vector3Int> wallPositionTypes = new HashSet<Vector3Int>();
      foreach(Vector2Int wallPosition in wallPositions)
      {
        int cDirectionAmount = 0;
        int dDirectionAmount = 0;
        int direction = 0;
        int direction2 = 0;
        bool n = false;
        bool e = false;
        bool s = false;
        bool w = false;
        bool tR = false;
        bool bR = false;
        bool bL = false;
        bool tL = false;
        foreach(Vector2Int cDirection in StaticTilemaps.cardinalDirections)
        {
          if(floorPositions.Contains(wallPosition + cDirection))
          {
            cDirectionAmount++;
            if(direction == 0)
            {
              n = true;
            }
            if(direction == 1)
            {
              e = true;
            }
            if(direction == 2)
            {
              s = true;
            }
            if(direction == 3)
            {
              w = true;
            }
          }
          direction++;
        }
        if(cDirectionAmount == 1)
        {
          if(s)
          {
            wallPositionTypes.Add(new Vector3Int(wallPosition.x, wallPosition.y, 0));
          }
          if(w)
          {
            wallPositionTypes.Add(new Vector3Int(wallPosition.x, wallPosition.y, 1));
          }
          if(n)
          {
            wallPositionTypes.Add(new Vector3Int(wallPosition.x, wallPosition.y, 2));
          }
          if(e)
          {
            wallPositionTypes.Add(new Vector3Int(wallPosition.x, wallPosition.y, 3));
          }
        } else if(s)
        {
          wallPositionTypes.Add(new Vector3Int(wallPosition.x, wallPosition.y, 0));
        } else if(w && e)
        {
          wallPositionTypes.Add(new Vector3Int(wallPosition.x, wallPosition.y, 4));
        } else if(n && w)
        {
          wallPositionTypes.Add(new Vector3Int(wallPosition.x, wallPosition.y, 5));
        } else if(n && e)
        {
          wallPositionTypes.Add(new Vector3Int(wallPosition.x, wallPosition.y, 6));
        }

        if(cDirectionAmount == 0)
        {
          foreach(Vector2Int dDirection in StaticTilemaps.diagionalDirections)
          {
            if(floorPositions.Contains(wallPosition + dDirection))
            {
              dDirectionAmount++;
              if(direction2 == 0)
              {
                tR = true;
              }
              if(direction2 == 1)
              {
                bR = true;
              }
              if(direction2 == 2)
              {
                bL = true;
              }
              if(direction2 == 3)
              {
                tL = true;
              }
            }
            direction2++;
          }

          if(dDirectionAmount == 1)
          {
            if(bR)
            {
              wallPositionTypes.Add(new Vector3Int(wallPosition.x, wallPosition.y, 3));
            }
            if(bL)
            {
              wallPositionTypes.Add(new Vector3Int(wallPosition.x, wallPosition.y, 1));
            }
            if(tR)
            {
              wallPositionTypes.Add(new Vector3Int(wallPosition.x, wallPosition.y, 7));
            }
            if(tL)
            {
              wallPositionTypes.Add(new Vector3Int(wallPosition.x, wallPosition.y, 8));
            }
          } else if(tL && bL)
          {
            wallPositionTypes.Add(new Vector3Int(wallPosition.x, wallPosition.y, 1));
          } else if(tR && bR)
          {
            wallPositionTypes.Add(new Vector3Int(wallPosition.x, wallPosition.y, 3));
          } else if(dDirectionAmount > 1)
          {
            wallPositionTypes.Add(new Vector3Int(wallPosition.x, wallPosition.y, 4));
          }
        }
      }
      return wallPositionTypes;
    }
}
