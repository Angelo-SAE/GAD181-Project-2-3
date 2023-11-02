using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
  public GameObject card1, card2;
  [SerializeField] private Button selectButton;

    void Update()
    {
      if(card1 != null && card2 != null)
      {
        OnlyOneCardSelected();
      }
    }

    private void OnlyOneCardSelected()
    {
      if(card1.GetComponent<Toggle>().isOn)
      {
        if(card2.GetComponent<Toggle>().isOn)
        {
          card1.GetComponent<Toggle>().isOn = false;
        } 
          card2.GetComponent<Toggle>().isOn = false;
          selectButton.interactable = true;
      } else if(card2.GetComponent<Toggle>().isOn)
      {
        if(card1.GetComponent<Toggle>().isOn)
        {
          card2.GetComponent<Toggle>().isOn = false;
        }
          card1.GetComponent<Toggle>().isOn = false;
          selectButton.interactable = true;
      } else {
        selectButton.interactable = false;
      }
    }

    public void SelectCard()
    {
      if(card1.GetComponent<Toggle>().isOn)
      {
        card1.GetComponent<Card>().Effect();
      } else if(card2.GetComponent<Toggle>().isOn)
      {
        card2.GetComponent<Card>().Effect();
      }
    }
}
