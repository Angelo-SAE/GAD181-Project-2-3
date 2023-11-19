using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyDisplay : MonoBehaviour
{

    void Update()
    {
        DisplayEnemyCount();
    }

    private void DisplayEnemyCount()
    {
      GetComponent<TMP_Text>().text = EnemyCount.enemyCount.ToString();
    }
}
