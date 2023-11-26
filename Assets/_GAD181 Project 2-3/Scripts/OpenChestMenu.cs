using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChestMenu : MonoBehaviour
{
  [SerializeField] private GameObject chestPanel, cardPanel;
  [SerializeField] private List<GameObject> cards;
  private bool menuOpen, interactable;
  public bool hasOpened;
  private GameObject cardStorage;
  public Vector2Int chestOverlap;

    void Update()
    {
      if(!hasOpened)
      {
        CheckInteractable();
        if(!GamePause.paused && interactable)
        {
          OpenChest();
        }
      }
    }

    private void CheckInteractable()
    {
      if(Physics2D.OverlapBox(new Vector2(chestOverlap.x + 0.5f, chestOverlap.y + 0.5f), new Vector2(2, 2), 0f,LayerMask.GetMask("Player")))
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
        GetComponent<TileMapPainter>().PaintChestOpenTile(chestOverlap);
        hasOpened = true;
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
        GamePause.Pause();
        menuOpen = true;
      }
    }

    public void CloseChest()
    {
      if(menuOpen)
      {
        Destroy(cardStorage);
        chestPanel.SetActive(false);
        GamePause.UnPause();
      }
    }
}
