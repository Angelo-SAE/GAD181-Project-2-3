using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float duration, shakeSize;

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.J))
      {
        StartCoroutine(ShakeScreen());
      }
    }

    public IEnumerator ShakeScreen()
    {
      Vector3 startPosition = new Vector3(0f, 0f, 0f);
      float timePassed = 0f;

      while(timePassed < duration && !GamePause.paused)
      {
        float x = Random.Range(-1, 1) * shakeSize;
        float y = Random.Range(-1, 1) * shakeSize;

        transform.localPosition = new Vector3(startPosition.x + x, startPosition.y + y, transform.localPosition.z);

        timePassed += Time.deltaTime;

        yield return null;
      }

      transform.localPosition = startPosition;
    }
}
