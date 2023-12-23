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
        player.GetComponent<Player>().bulletAmountIncrease++;
      }
      if(whichCard == 1)
      {
        player.GetComponent<Gun>().reloadSpeed -= (player.GetComponent<Gun>().reloadSpeed/10);
        player.GetComponent<Player>().reloadSpeedIncrease++;
      }
      if(whichCard == 2)
      {
        player.GetComponent<Gun>().attackSpeed -= (player.GetComponent<Gun>().attackSpeed/10);
        player.GetComponent<Player>().fireRateIncrease++;
      }
      if(whichCard == 3)
      {
        player.GetComponent<Player>().movementSpeed += 0.5f;
        player.GetComponent<Player>().movementSpeedIncrease++;
      }
      if(whichCard == 4)
      {
        player.GetComponent<Gun>().bulletDamage += 10f;
        player.GetComponent<Player>().damageIncrease++;
      }
      if(whichCard == 5)
      {
        player.GetComponent<Player>().maxHealth += 2;
        player.GetComponent<Player>().health++;
        player.GetComponent<Player>().health++;
        player.GetComponent<Player>().healthIncrease++;
      }
      if(whichCard == 6)
      {
        player.GetComponent<Gun>().maxAmmo += 4;
        player.GetComponent<Player>().ammoIncrease++;
      }
    }
}
