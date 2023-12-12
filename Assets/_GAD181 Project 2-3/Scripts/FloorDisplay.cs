using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloorDisplay : MonoBehaviour
{
  [SerializeField] private GameObject floorCountObject;
  void Update()
  {
    SetFloorNumber();
  }

  private void SetFloorNumber()
  {
    GetComponent<TMP_Text>().text = (floorCountObject.GetComponent<ExitLadder>().roomsCleared + 1).ToString();
  }
}
