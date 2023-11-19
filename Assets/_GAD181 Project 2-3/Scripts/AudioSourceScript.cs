using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceScript : MonoBehaviour
{
    [SerializeField] private float waitTime;

    void Start()
    {
        StartCoroutine(KillMe());
    }

    private IEnumerator KillMe()
    {
      yield return new WaitForSeconds(waitTime);
      Destroy(gameObject);
    }
}
