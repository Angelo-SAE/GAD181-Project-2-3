using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestClose : MonoBehaviour
{
  public GameObject card1, card2;

  public void CloseChest()
  {
    Destroy(card1);
    Destroy(card2);
    gameObject.SetActive(false);
    GamePause.UnPause();
  }
}
