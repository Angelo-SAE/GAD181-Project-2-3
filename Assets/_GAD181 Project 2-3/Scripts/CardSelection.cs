using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{

    private void SelectCard()
    {
      gameObject.GetComponent<Card>().Effect();
      GetComponentInParent<ChestClose>().CloseChest();
    }
}
