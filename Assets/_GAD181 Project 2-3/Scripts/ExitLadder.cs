using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLadder : MonoBehaviour
{

  private bool interactable;
  [SerializeField] private GameObject winMenu, exitPrompt;
  public Vector2Int holeOverlap;
  public int roomsCleared, roomsToWin;
  public bool holeClosed;


  void Update()
  {
    CheckInteractable();
    if(!holeClosed && interactable && !EnemyCount.bossAlive)
    {
      exitPrompt.SetActive(true);
    } else {
      exitPrompt.SetActive(false);
    }
    if(!GamePause.paused && interactable && Input.GetButtonDown("Interact"))
    {
      ExitMenu();
    }
    if(EnemyCount.enemyCount <= 0 && holeClosed && !EnemyCount.bossAlive)
    {
      GetComponent<TileMapPainter>().PaintHoleOpenTile(holeOverlap);
      holeClosed = false;
    }
  }

    private void CheckInteractable()
    {
      if(Physics2D.OverlapBox(new Vector2(holeOverlap.x + 0.5f, holeOverlap.y + 0.5f), new Vector2(2f, 2f), 0f,LayerMask.GetMask("Player")))
      {
        interactable = true;
      } else {
        interactable = false;
      }
    }

    private void ExitMenu()
    {
      if(EnemyCount.enemyCount <= 0 && roomsCleared == roomsToWin && !EnemyCount.bossAlive)
      {
        GamePause.Pause();
        winMenu.SetActive(true);
      } else if(EnemyCount.enemyCount <= 0 && !EnemyCount.bossAlive)
      {
        GetComponent<Generate>().GenerateMap();
        GetComponent<OpenChestMenu>().hasOpened = false;
        roomsCleared++;
      }
    }
}
