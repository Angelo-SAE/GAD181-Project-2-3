using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChestMenu : MonoBehaviour
{
  [SerializeField] private GameObject chestPanel;

    void Update()
    {
      if(!GamePause.paused)
      {

      }
      OpenChest();
    }

    private void OpenChest()
    {
      if(Input.GetButtonDown("Interact"))
      {
        chestPanel.SetActive(true);
        GamePause.paused = true;
        Time.timeScale = 0;
      }

      if(Input.GetKeyDown(KeyCode.F))
      {
        chestPanel.SetActive(false);
        GamePause.paused = false;
        Time.timeScale = 1;
      }
    }
}
