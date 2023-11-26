using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCounter : MonoBehaviour
{

    void Update()
    {
      SetEnemyCount();
    }

    private void SetEnemyCount()
    {
      GetComponent<TMP_Text>().text = EnemyCount.enemyCount.ToString();
    }
}
