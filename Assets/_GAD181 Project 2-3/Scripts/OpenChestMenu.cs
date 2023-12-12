using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChestMenu : MonoBehaviour
{
  [SerializeField] private GameObject chestPanel, card1Storage, card2Storage;
  [SerializeField] private List<GameObject> cards;
  private bool menuOpen, interactable;
  public bool hasOpened;
  private GameObject card1, card2;
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
        List<GameObject> tempCards = new List<GameObject>(cards);
        for(int a = 0; a < 2; a++)
        {
          int rand = Random.Range(0, tempCards.Count);
          if(a == 0)
          {
            card1 = Instantiate(tempCards[rand], card1Storage.transform.position, tempCards[rand].transform.localRotation, card1Storage.transform);
            chestPanel.GetComponent<ChestClose>().card1 = card1;
          } else {
            card2 = Instantiate(tempCards[rand], card2Storage.transform.position, tempCards[rand].transform.localRotation, card2Storage.transform);
            chestPanel.GetComponent<ChestClose>().card2 = card2;
          }
          tempCards.RemoveAt(rand);
        }
        GamePause.Pause();
        menuOpen = true;
      }
    }

    public void CloseChest()
    {
      if(menuOpen)
      {
        Destroy(card1);
        Destroy(card2);
        chestPanel.SetActive(false);
        GamePause.UnPause();
      }
    }
}
