using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
  [SerializeField] private int whichCard;
  private GameObject player;

  void Start()
  {
    player = GameObject.Find("Player");
  }

    public void Effect()
    {
      if(whichCard == 0)
      {
        player.GetComponent<Gun>().bulletAmount++;
      }
      if(whichCard == 1)
      {
        player.GetComponent<Gun>().reloadSpeed -= (player.GetComponent<Gun>().reloadSpeed/10);
      }
      if(whichCard == 2)
      {
        player.GetComponent<Gun>().attackSpeed -= (player.GetComponent<Gun>().attackSpeed/10);
      }
      if(whichCard == 3)
      {
        player.GetComponent<Player>().movementSpeed += 0.5f;
      }
      if(whichCard == 4)
      {
        player.GetComponent<Gun>().bulletDamage += 10f;
      }
    }
}
