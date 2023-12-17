using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrossBowTrapGeneration : MonoBehaviour
{
    [SerializeField] private int trapAmount;
    [SerializeField] private GameObject crossbowTrap;
    private GameObject CrossbowTrapHolder;

    public HashSet<Vector2Int> GenerateCrossbow(HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> wallPositions, HashSet<Vector2Int> objectPositions)
    {
      if(CrossbowTrapHolder != null)
      {
        Destroy(CrossbowTrapHolder);
      }
      CrossbowTrapHolder = new GameObject("CrossbowTrapHolder");
      HashSet<Vector2Int> crossbowPositions = new HashSet<Vector2Int>();
      int l = 0;
      for(int a = trapAmount; a > 0;)
      {
        Vector2Int trapPosition = floorPositions.ElementAt(Random.Range(0,floorPositions.Count));
        int cDirectionAmount = 0;
        int dDirectionAmount = 0;
        int cObj = 0;
        int direction = 0;
        int direction2 = 0;
        bool n = false;
        bool e = false;
        bool s = false;
        bool w = false;
        bool nE = false;
        bool sE = false;
        bool sW = false;
        bool nW = false;
        if(!objectPositions.Contains(trapPosition))
        {
          foreach(Vector2Int cDirection in StaticTilemaps.cardinalDirections)
          {
            if(objectPositions.Contains(trapPosition + cDirection))
            {
              cObj++;
            }
            if(wallPositions.Contains(trapPosition + cDirection))
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
          foreach(Vector2Int dDirection in StaticTilemaps.diagionalDirections)
          {
            if(wallPositions.Contains(trapPosition + dDirection) || objectPositions.Contains(trapPosition + dDirection))
            {
              dDirectionAmount++;
              if(direction2 == 0)
              {
                nE = true;
              }
              if(direction2 == 1)
              {
                sE = true;
              }
              if(direction2 == 2)
              {
                sW = true;
              }
              if(direction2 == 3)
              {
                nE = true;
              }
            }
            direction2++;
          }

          if(dDirectionAmount == 0)
          {
            if(dDirectionAmount != 4 && cObj == 0)
            {
              if(cDirectionAmount == 1)
              {
                if(n && !sE && !sW)
                {
                  a--;
                  objectPositions.Add(trapPosition);
                  Instantiate(crossbowTrap, new Vector3(trapPosition.x + 0.5f, trapPosition.y + 0.5f, crossbowTrap.transform.position.z), Quaternion.Euler(0f, 0f, 270f), CrossbowTrapHolder.transform);
                }
                if(e && !sW && !nW)
                {
                  a--;
                  objectPositions.Add(trapPosition);
                  Instantiate(crossbowTrap, new Vector3(trapPosition.x + 0.5f, trapPosition.y + 0.5f, crossbowTrap.transform.position.z), Quaternion.Euler(0f, 0f, 180f), CrossbowTrapHolder.transform);
                }
                if(s && !nW && !nE)
                {
                  a--;
                  objectPositions.Add(trapPosition);
                  Instantiate(crossbowTrap, new Vector3(trapPosition.x + 0.5f, trapPosition.y + 0.5f, crossbowTrap.transform.position.z), Quaternion.Euler(0f, 0f, 90f), CrossbowTrapHolder.transform);
                }
                if(w && !nE && !sE)
                {
                  a--;
                  objectPositions.Add(trapPosition);
                  Instantiate(crossbowTrap, new Vector3(trapPosition.x + 0.5f, trapPosition.y + 0.5f, crossbowTrap.transform.position.z), Quaternion.Euler(0f, 0f, 0f), CrossbowTrapHolder.transform);
                }
              }
              if(cDirectionAmount == 2)
              {
                if(n && e && !sW)
                {
                  a--;
                  objectPositions.Add(trapPosition);
                  Instantiate(crossbowTrap, new Vector3(trapPosition.x + 0.5f, trapPosition.y + 0.5f, crossbowTrap.transform.position.z), Quaternion.Euler(0f, 0f, 270f), CrossbowTrapHolder.transform);
                }
                if(e && s && !nW)
                {
                  a--;
                  objectPositions.Add(trapPosition);
                  Instantiate(crossbowTrap, new Vector3(trapPosition.x + 0.5f, trapPosition.y + 0.5f, crossbowTrap.transform.position.z), Quaternion.Euler(0f, 0f, 180f), CrossbowTrapHolder.transform);
                }
                if(s && w && !nE)
                {
                  a--;
                  objectPositions.Add(trapPosition);
                  Instantiate(crossbowTrap, new Vector3(trapPosition.x + 0.5f, trapPosition.y + 0.5f, crossbowTrap.transform.position.z), Quaternion.Euler(0f, 0f, 90f), CrossbowTrapHolder.transform);
                }
                if(w && n && !sE)
                {
                  a--;
                  objectPositions.Add(trapPosition);
                  Instantiate(crossbowTrap, new Vector3(trapPosition.x + 0.5f, trapPosition.y + 0.5f, crossbowTrap.transform.position.z), Quaternion.Euler(0f, 0f, 0f), CrossbowTrapHolder.transform);
                }
              }
            }
          } else {
            if(l == 100)
            {
              a = 0;
            } else {
              l++;
            }
          }
        }
      }
      return crossbowPositions;
    }

}
