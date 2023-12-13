using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoWarning : MonoBehaviour
{

    void OnEnable()
    {
      StartCoroutine(KillMe());
    }

    private IEnumerator KillMe()
    {
      yield return new WaitForSeconds(0.5f);
      gameObject.SetActive(false);
    }

}
