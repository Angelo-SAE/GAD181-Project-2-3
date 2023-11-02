using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChestMenu : MonoBehaviour
{
  [SerializeField] private GameObject chestPanel, cardPanel;
  [SerializeField] private List<GameObject> cards;
  private bool menuOpen, interactable;
  private GameObject cardStorage;

    void Update()
    {
      CheckInteractable();
      if(!GamePause.paused && interactable)
      {
        OpenChest();
      }
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
        cardStorage = Instantiate(cardPanel, new Vector3(0f, 0f, 0f), transform.rotation, chestPanel.transform);
        List<GameObject> tempCards = new List<GameObject>(cards);
        for(int a = 0; a < 2; a++)
        {
          int rand = Random.Range(0, tempCards.Count);
          GameObject card = Instantiate(tempCards[rand], new Vector3(-182f * (1 - (a * 2)), 31f, 0f), transform.rotation, cardStorage.transform);
          if(a == 0)
          {
            chestPanel.GetComponent<CardSelection>().card1 = card;
          } else {
            chestPanel.GetComponent<CardSelection>().card2 = card;
          }
          tempCards.RemoveAt(rand);
        }
        cardStorage.transform.position = new Vector3(960f, 620f, 0f);
        GamePause.paused = true;
        Time.timeScale = 0;
        menuOpen = true;
      }
    }

    public void CloseChest()
    {
      if(menuOpen)
      {
        Destroy(cardStorage);
        chestPanel.SetActive(false);
        GamePause.paused = false;
        Time.timeScale = 1;
      }
    }
}
