using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatSetter : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text statsText;
    [SerializeField] private int upgradeNumber;

    void Update()
    {
      UpdateStats();
    }

    private void UpdateStats()
    {
      if(upgradeNumber == 0)
      {
        statsText.text = ": " + player.GetComponent<Player>().bulletAmountIncrease.ToString();
      }
      if(upgradeNumber == 1)
      {
        statsText.text = ": " + player.GetComponent<Player>().reloadSpeedIncrease.ToString();
      }
      if(upgradeNumber == 2)
      {
        statsText.text = ": " + player.GetComponent<Player>().fireRateIncrease.ToString();
      }
      if(upgradeNumber == 3)
      {
        statsText.text = ": " + player.GetComponent<Player>().movementSpeedIncrease.ToString();
      }
      if(upgradeNumber == 4)
      {
        statsText.text = ": " + player.GetComponent<Player>().damageIncrease.ToString();
      }
      if(upgradeNumber == 5)
      {
        statsText.text = ": " + player.GetComponent<Player>().healthIncrease.ToString();
      }
      if(upgradeNumber == 6)
      {
        statsText.text = ": " + player.GetComponent<Player>().ammoIncrease.ToString();
      }
    }
}
