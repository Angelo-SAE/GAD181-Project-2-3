using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChestMenu : MonoBehaviour
{
  [SerializeField] private GameObject chestPanel;
  private bool menuOpen, interactable;

    void Update()
    {
      CheckInteractable();
      if(!GamePause.paused && interactable)
      {
        OpenChest();
      }
      CloseChest();
    }

    private void CheckInteractable()
    {
      if(Physics2D.OverlapBox(new Vector3(9.5f, 1.5f, transform.position.z), new Vector2(1.5f, 1.5f), 0f,LayerMask.GetMask("Player")))
      {
        interactable = true;
      } else {
        interactable = false;
      }
    }

    private void OpenChest()
    {
      if(Input.GetButtonDown("Interact"))
      {
        chestPanel.SetActive(true);
        GamePause.paused = true;
        Time.timeScale = 0;
        menuOpen = true;
      }
    }

    private void CloseChest()
    {
      if(menuOpen && Input.GetKeyDown(KeyCode.F))
      {
        chestPanel.SetActive(false);
        GamePause.paused = false;
        Time.timeScale = 1;
      }
    }
}
