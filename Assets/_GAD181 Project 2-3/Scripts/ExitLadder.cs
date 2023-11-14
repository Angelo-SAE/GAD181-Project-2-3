using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLadder : MonoBehaviour
{

  private bool interactable;
  [SerializeField] private GameObject winMenu;


  void Update()
  {
    CheckInteractable();
    if(!GamePause.paused && interactable && Input.GetButtonDown("Interact"))
    {
      ExitMenu();
    }
  }

    private void CheckInteractable()
    {
      if(Physics2D.OverlapBox(new Vector3(-1.5f, 8.5f, transform.position.z), new Vector2(1.5f, 1.5f), 0f,LayerMask.GetMask("Player")))
      {
        interactable = true;
      } else {
        interactable = false;
      }
    }

    private void ExitMenu()
    {
      if(EnemyCount.enemyCount == 0)
      {
        GamePause.Pause();
        winMenu.SetActive(true);
      }
    }
}
